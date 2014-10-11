using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;
using Masa.Lib.XNA.Input;

namespace Masa.Triangle
{
	public class TriangleGame : Game
	{
		GraphicsDeviceManager graphicDeviceManager;
		public InputManager Input { get; private set; }

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

		protected override void Initialize()
		{
			Window.AllowUserResizing = false;
			Window.Title = "Triangle";
			Input = new InputManager();
			base.Initialize();
		}

		protected override void Dispose(bool disposeManagedResources)
		{
			Input.Dispose();
			base.Dispose(disposeManagedResources);
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			Input.Update();
			if (Input.ControlState.Esc.JustPush)
			{
				Exit();
			}
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			base.Draw(gameTime);
		}
	}
}
