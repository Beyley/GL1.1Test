using System.Drawing;
using Silk.NET.OpenGL.Legacy;

namespace GL1Test;

public abstract class Drawable {
	public Color Color = new(255, 255, 255, 255);
	
	public abstract void Draw(GL gl);
	public abstract void Update(double time);
}
