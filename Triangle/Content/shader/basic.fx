float4x4 worldViewProjection;

float4 vs(float4 p : POSITION0) : SV_POSITION{
	return mul(p, worldViewProjection);
	return p;
}

float4 ps() : SV_TARGET{
	return float4(1, 1, 0.5, 1);
}


technique t
{
	pass p
	{
		Profile = 10;
		VertexShader = vs;
		PixelShader = ps;
	}
}
