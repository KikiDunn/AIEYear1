﻿using System;

namespace MathLibrary
{
	public struct Vector2
	{
		public float x;
		public float y;

		public Vector2(float x = 0.0f, float y = 0.0f)
		{
			this.x = x;
			this.y = y;
		}
		
		public static Vector2 operator +(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x + b.x, a.y + b.y);
		}
		public static Vector2 operator -(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x - b.x, a.y - b.y);
		}
		public static Vector2 operator *(Vector2 a, float b)
		{
			return new Vector2(a.x * b, a.y * b);
		}
		public static Vector2 operator *(float a, Vector2 b)
		{
			return b*a;
		}
		public float Magnitude()
		{
			return (float)Math.Sqrt((x * x) + (y * y));
		}
		public Vector2 Normalise()
		{
			float magnitude = Magnitude();
			if(magnitude != 0)
			{
				x /= magnitude;
				y /= magnitude;
			}
			return this;
		}
		public float Dot(Vector2 b)
		{
			return x * b.x + y*b.y;
		}

	}	
}
