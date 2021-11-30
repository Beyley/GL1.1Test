using System.Drawing;
using System.Numerics;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL.Legacy;
using Silk.NET.Windowing;
using Silk.NET.Windowing.Sdl;
using ContextSourceExtensions = Silk.NET.OpenGL.Legacy.ContextSourceExtensions;

namespace GL1Test;

internal class Program {
	private static IWindow       window;
	private static WindowOptions options;

	private static GL gl;

	public static List<Drawable> Drawables = new();

	public static Color BackgroundColor = new(System.Drawing.Color.Black);

	public static TriangleDrawable triangle;

	private static void Main(string[] args) {
		options = WindowOptions.Default;

		// options.WindowBorder = WindowBorder.Fixed;
		options.Size         = new(800, 600);
		options.Title        = "GL1Test";

		options.API = new GraphicsAPI(ContextAPI.OpenGL, new APIVersion(1, 1));

		SdlWindowing.RegisterPlatform();
		Window.PrioritizeSdl();
		window = Window.Create(options);

		//Assign events
		window.Load   += OnLoad;
		window.Update += OnUpdate;
		window.Render += OnRender;
		
		window.Resize += OnResize;

		//Run the window
		window.Run();
	}
	
	private static void OnResize(Vector2D<int> newSize) {
		gl.Viewport(0, 0, (uint)newSize.X, (uint)newSize.Y);
		gl.MatrixMode(MatrixMode.Projection);
		gl.LoadIdentity();
		gl.Ortho(0, newSize.X, newSize.Y, 0, 1, 0);
	}

	private static void OnLoad() {
		gl = window.CreateLegacyOpenGL();

		//Set-up input context.
		IInputContext input = window.CreateInput();

		foreach (IKeyboard t in input.Keyboards)
			t.KeyDown += KeyDown;
		
		OnResize(options.Size);
		
		Drawables.Add(triangle = new TriangleDrawable(new(400, 500f), new(0, 600), new(800, 600)));
		Drawables.Add(new RectangleDrawable(new(400, 400), new(500, 500)));
		Drawables.Add(new PolygonDrawable(new [] {
			new Vector2(200, 200), 
			new Vector2(220, 180), 
			new Vector2(230, 200),
			new Vector2(250, 220),
			new Vector2(200, 220), 
		}));
		
		Drawables.Add(new CircleDrawable(new(100), 20f));
	}

	private static void OnRender(double time) {
		gl.ClearColor(BackgroundColor);
		gl.ClearDepth(1f);
		gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

		Color lastColor = new(255, 255, 255, 255);
		
		gl.Color4(lastColor.R, lastColor.G, lastColor.B, lastColor.A);
		for (int i = 0; i < Drawables.Count; i++) {
			Drawable drawable = Drawables[i];
			if (drawable.Color != lastColor) {
				lastColor = drawable.Color;
				gl.Color4(lastColor.R, lastColor.G, lastColor.B, lastColor.A);
			}
			drawable.Draw(gl);
		}
	
		gl.Flush();
		
		//Here all rendering should be done.
	}

	private static void OnUpdate(double time) {
		for (int i = 0; i < Drawables.Count; i++) {
			Drawable drawable = Drawables[i];
			drawable.Update(time);
		}

		triangle.P2.X += (float)(time * 100f);

		if (triangle.P2.X > 800) triangle.P2.X = 0;

		unchecked {
			triangle.Color.R += (byte)(time * 300f);
			triangle.Color.G += (byte)(time * 200f);
			triangle.Color.B += (byte)(time * 700f);
		}
	}

	private static void KeyDown(IKeyboard arg1, Key arg2, int arg3) {
		//Check to close the window on escape.
		if (arg2 == Key.Escape)
			window.Close();
	}
}
