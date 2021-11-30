using System.Numerics;
using Silk.NET.OpenGL.Legacy;

namespace GL1Test; 

public class PolygonDrawable : Drawable {
	public Vector2[] Points;

	public PrimitiveType Type = PrimitiveType.Polygon;

	public PolygonDrawable(Vector2[] points) {
		this.Points = points;
		
		this.LineWidth = 1f;
	}
	
	public override void Draw(GL gl) {
		gl.Begin(this.Type);

		for (int i = 0; i < this.Points.Length; i++) {
			Vector2 point = this.Points[i];
			
			gl.Vertex2(point.X, point.Y);
		}

		gl.End();
	}
	
	public override void Update(double time) {
		// throw new NotImplementedException();
	}
}
