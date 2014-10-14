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
		public static TriangleGame Game { get; private set; }
		GameObjectBase obj;

		public static void Main()
		{
			using (Game = new TriangleGame())
			{
				Game.Run();
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

		protected override void LoadContent()
		{
			base.LoadContent();
			Content.RootDirectory = "Content";
			obj = new GameObjectBase();
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
			obj.Draw();
			base.Draw(gameTime);
		}
	}
}
