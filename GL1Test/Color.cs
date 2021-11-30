namespace GL1Test; 

public class Color {
	public byte R;
	public byte G;
	public byte B;
	public byte A;

	public float Rf {
		get => this.R / 255f;
		set => this.R = (byte)(Math.Clamp(value, 0, 1) * 255);
	}
	public float Gf {
		get => this.G / 255f;
		set => this.G = (byte)(Math.Clamp(value, 0, 1) * 255);
	}
	public float Bf {
		get => this.B / 255f;
		set => this.B = (byte)(Math.Clamp(value, 0, 1) * 255);
	}
	public float Af {
		get => this.A / 255f;
		set => this.A = (byte)(Math.Clamp(value, 0, 1) * 255);
	}
	
	public Color(byte r, byte g, byte b, byte a) {
		this.R = r;
		this.G = g;
		this.B = b;
		this.A = a;
	}

	public Color(System.Drawing.Color color) {
		this.R = color.R;
		this.G = color.G;
		this.B = color.B;
		this.A = color.A;
	}
	
	public static implicit operator System.Drawing.Color(Color color) 
		=> System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
	public static explicit operator Color(System.Drawing.Color color) => new (color);
}
