using System.Numerics;
using Silk.NET.OpenGL.Legacy;

namespace GL1Test; 

public class CircleDrawable : Drawable {
	private Vector2[] points;

	public Vector2 Position;
	
	public PrimitiveType Type = PrimitiveType.Polygon;
	
	private double radius;
	public double Radius {
		get => this.radius;
		set {
			this.radius = value;
			this.Recalculate();
		}
	}
	
	private int quality;
	public int Quality {
		get => this.quality;
		set {
			this.quality = value;
			this.Recalculate();
		}
	}

	public CircleDrawable(Vector2 position, double radius, int quality = 50) {
		this.Position = position;
		this.radius   = radius;
		this.quality  = quality;

		this.LineWidth = 1f;
		
		this.Recalculate();
	}

	private void Recalculate() {
		this.points = new Vector2[this.quality];
		
		for (int i = 0; i < this.Quality; i++) {    
			double angle = 2 * Math.PI *i / this.quality; 
			this.points[i] = new((float)(Math.Cos(angle) * this.radius) + this.Position.X, (float)(Math.Sin(angle) * this.radius) + this.Position.Y); 
		} 
	}
	
	public override void Draw(GL gl) {
		gl.Begin(this.Type);

		for (int i = 0; i < this.points.Length; i++) {
			Vector2 point = this.points[i];
			
			gl.Vertex2(point.X, point.Y);
		}

		gl.End();
	}
	public override void Update(double time) {
		// throw new NotImplementedException();
	}
}
