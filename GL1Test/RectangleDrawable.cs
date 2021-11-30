using System.Numerics;
using Silk.NET.OpenGL.Legacy;

namespace GL1Test; 

public class RectangleDrawable : Drawable {
	public Vector2 P1;
	public Vector2 P2;

	public RectangleDrawable(Vector2 p1, Vector2 p2) {
		this.P1 = p1;
		this.P2 = p2;
	}

	public override void Draw(GL gl) {
		gl.Rect(this.P1.X, this.P1.Y, this.P2.X, this.P2.Y);
	}
	
	public override void Update(double time) {
		// throw new NotImplementedException();
	}
}
