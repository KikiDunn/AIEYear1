using System;

namespace MathLibrary
{
	public struct Vector4
	{
		public float x;
		public float y;
		public float z;
		public float w;

		public Vector4(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 0.0f)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public static Vector4 operator +(Vector4 a, Vector4 b)
		{
			return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		}
		public static Vector4 operator -(Vector4 a, Vector4 b)
		{
			return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		}
		public static Vector4 operator *(Vector4 a, float b)
		{
			return new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
		}
		public static Vector4 operator *(float a, Vector4 b)
		{
			return b * a;
		}
		public float Magnitude()
		{
			return (float)Math.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
		}
		public void Normalise()
		{
			float magnitude = Magnitude();
			if (magnitude != 0)
			{
				x /= magnitude;
				y /= magnitude;
				z /= magnitude;
				w /= magnitude;
			}
		}
		public float Dot(Vector4 b)
		{
			return 0f;
		}
		public Vector4 Cross(Vector4 b)
		{
			return new Vector4(
				(y * b.z) - (z * b.y),
				(z * b.x) - (x * b.z),
				(x * b.y) - (y * b.x));
		}
	}
}
