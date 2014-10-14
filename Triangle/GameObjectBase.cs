using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using Masa.Lib;
using SharpDX.Toolkit.Graphics;

namespace Masa.Triangle
{
	public class GameObjectBase : PoolObjectBase
	{
		GraphicsDevice Device { get { return TriangleGame.Game.GraphicsDevice; } }

		Buffer<Vector3> vertex;
		Buffer<short> index;
		VertexInputLayout layout;
		Effect ef;

		public GameObjectBase()
			: base()
		{
			vertex = SharpDX.Toolkit.Graphics.Buffer.Vertex.New<Vector3>(Device, new[] {
				new Vector3(-1, 0, -1),
				new Vector3(-1, 0, 1),
				new Vector3(1, 0, 1),
				new Vector3(1, 0, -1),
				new Vector3(0, 1, 0),
				//new Vector3(0.2f, .2f, 0),
				//new Vector3(.2f, -.2f, 0),
				//new Vector3(-0.2f, .2f, 0),
			});
			index = SharpDX.Toolkit.Graphics.Buffer.Index.New<short>(Device, new short[] {
				0, 1, 4,
				1, 2, 4,
				2, 3, 4,
				3, 0, 4,
				//0, 1, 2
			});
			layout = VertexInputLayout.New(VertexBufferLayout.New(0, VertexElement.Position<Vector3>(0)));
			ef = TriangleGame.Game.Content.Load<Effect>("shader\\basic");
		}

		public void Update()
		{

		}

		public void Draw() 
		{
			Device.SetVertexBuffer(vertex);
			Device.SetIndexBuffer(index, false);
			Device.SetVertexInputLayout(layout);
			Device.SetRasterizerState(Device.RasterizerStates.WireFrameCullNone);
			Device.SetDepthStencilState(Device.DepthStencilStates.None);
			ef.Parameters["worldViewProjection"].SetValue(Matrix.Identity * Matrix.LookAtRH(new Vector3(10, 3, 1), new Vector3(0, 0, 0), Vector3.Up) * Matrix.PerspectiveFovRH(.5f, Device.Viewport.AspectRatio, 0.1f, 100));
			ef.CurrentTechnique.Passes[0].Apply();
			//Device.DrawAuto(PrimitiveType.TriangleList);
			Device.DrawIndexed(PrimitiveType.TriangleList, index.ElementCount);
		}

	}
}
