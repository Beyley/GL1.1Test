using System.Numerics;
using Silk.NET.OpenGL.Legacy;

namespace GL1Test;

public class TriangleDrawable : Drawable {
	public Vector2 P1;
	public Vector2 P2;
	public Vector2 P3;

	public TriangleDrawable(Vector2 p1, Vector2 p2, Vector2 p3) {
		this.P1 = p1;
		this.P2 = p2;
		this.P3 = p3;
	}

	public override void Draw(GL gl) {
		gl.Begin(PrimitiveType.Triangles);
		
		gl.Vertex2(this.P1.X, this.P1.Y);
		gl.Vertex2(this.P2.X, this.P2.Y);
		gl.Vertex2(this.P3.X, this.P3.Y);
		
		gl.End();
	}

	public override void Update(double time) {
		// this.P1.X += (float)time;
		//
		// if (this.P1.X > 1) this.P1.X = -1;
		//
		// unchecked {
		// 	this.Color.R += (byte)(time * 2000);
		// 	this.Color.G += (byte)(time * 1000);
		// 	this.Color.B += (byte)(time * 3000);
		// }

		// if (this.Color.R == 255) this.Color.R = 0;
	}
}
