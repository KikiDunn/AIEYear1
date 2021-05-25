using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	public struct Matrix3
	{
		public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
		public Matrix3(float n1, float n2, float n3,
					   float n4, float n5, float n6,
					   float n7, float n8, float n9)
		{
			m1 = n1;
			m2 = n2;
			m3 = n3;
			m4 = n4;
			m5 = n5;
			m6 = n6;
			m7 = n7;
			m8 = n8;
			m9 = n9;
		}
		public Matrix3 Identity()
		{
			m1 = 1; m4 = 0; m7 = 0;
			m2 = 0; m5 = 1; m8 = 0;
			m3 = 0; m6 = 0; m9 = 1;
			return this;
		}
		public static Vector3 operator *(Matrix3 a, Vector3 b)
		{
			return new Vector3(a.m1 * b.x + a.m4 * b.y + a.m7 * b.z, 
							   a.m2 * b.x + a.m5 * b.y + a.m8 * b.z, 
							   a.m3 * b.x + a.m6 * b.y + a.m9 * b.z);
		}

		public static Matrix3 operator *(Matrix3 a, Matrix3 b)
		{
			return new Matrix3(a.m1 * b.m1 + a.m4 * b.m2 + a.m7 * b.m3, a.m2 * b.m1 + a.m5 * b.m2 + a.m8 * b.m3, a.m3 * b.m1 + a.m6 * b.m2 + a.m9 * b.m3,
							   a.m1 * b.m4 + a.m4 * b.m5 + a.m7 * b.m6, a.m2 * b.m4 + a.m5 * b.m5 + a.m8 * b.m6, a.m3 * b.m4 + a.m6 * b.m5 + a.m9 * b.m6,
							   a.m1 * b.m7 + a.m4 * b.m8 + a.m7 * b.m9, a.m2 * b.m7 + a.m5 * b.m8 + a.m8 * b.m9, a.m3 * b.m7 + a.m6 * b.m8 + a.m9 * b.m9);
		}
		public void SetRotateX(float fRad)
		{
			m1 = 1;
			m5 = (float)Math.Cos(fRad);
			m6 = (float)Math.Sin(fRad);
			m8 = (float)-Math.Sin(fRad);
			m9 = (float)Math.Cos(fRad);
		}

		public void SetRotateY(float fRad)
		{
			m1 = (float)Math.Cos(fRad);
			m3 = (float)-Math.Sin(fRad);
			m5 = 1;
			m7 = (float)Math.Sin(fRad);
			m9 = (float)Math.Cos(fRad);
		}

		public Matrix3 SetRotateZ(float fRad)
		{
			m1 = (float)Math.Cos(fRad);
			m2 = (float)Math.Sin(fRad);
			m4 = (float)-Math.Sin(fRad);
			m5 = (float)Math.Cos(fRad);
			m9 = 1;
			return this;
		}

		//Extra helpful functions
		public void SetTranslation(float x, float y)
		{
		}

		public void SetTranslation(Vector2 pos)
		{
		}

		public void SetScale(float x, float y)
		{
		}

		public void SetScale(Vector2 scale)
		{
		}
	}
}
