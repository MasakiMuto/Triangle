using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;

namespace Triangle
{
	public class TriangleGame : Game
	{
		GraphicsDeviceManager graphicDeviceManager;

		public static void Main()
		{
			using (var game = new TriangleGame())
			{
				game.Run();
			}
		}

		public TriangleGame()
		{
			graphicDeviceManager = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferHeight = 540,
				PreferredBackBufferWidth = 960,
			};
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			base.Draw(gameTime);
		}
	}
}
