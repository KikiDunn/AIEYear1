using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	public struct Matrix4
	{
		public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;
		public Matrix4(bool bDefault = true) : this(1f, 1f, 1f) { }
		public Matrix4(float x, float y, float z, float w = 1f) : this(x, 0, 0, 0,
																	   0, y, 0, 0,
																	   0, 0, z, 0,
																	   0, 0, 0, w) { }
		public Matrix4(float n1,  float n2,  float n3,  float n4,
					   float n5,  float n6,  float n7,  float n8, 
					   float n9,  float n10, float n11, float n12,
					   float n13, float n14, float n15, float n16)
		{
			m1 = n1; m5 = n5; m9 = n9;   m13 = n13;
			m2 = n2; m6 = n6; m10 = n10; m14 = n14;
			m3 = n3; m7 = n7; m11 = n11; m15 = n15;
			m4 = n4; m8 = n8; m12 = n12; m16 = n16;
		}

		public static Vector4 operator *(Matrix4 a, Vector4 b)
		{
			return new Vector4(a.m1 * b.x + a.m5 * b.y + a.m9  * b.z + a.m13 * b.w,
							   a.m2 * b.x + a.m6 * b.y + a.m10 * b.z + a.m14 * b.w,
							   a.m3 * b.x + a.m7 * b.y + a.m11 * b.z + a.m15 * b.w,
							   a.m4 * b.x + a.m8 * b.y + a.m12 * b.z + a.m16 * b.w);
		}

		public static Matrix4 operator *(Matrix4 a, Matrix4 b)
		{
			return new Matrix4(a.m1  * b.m1  + a.m5  * b.m2  + a.m9  * b.m3  + a.m13 * b.m4  ,  a.m2  * b.m1  + a.m6  * b.m2  + a.m10  * b.m3  + a.m14 * b.m4  ,  a.m3  * b.m1  + a.m7  * b.m2  + a.m11 * b.m3  + a.m15 * b.m4  ,  a.m4  * b.m1  + a.m8  * b.m2  + a.m12  * b.m3  + a.m16 * b.m4,
							   a.m1  * b.m5  + a.m5  * b.m6  + a.m9  * b.m7  + a.m13 * b.m8  ,  a.m2  * b.m5  + a.m6  * b.m6  + a.m10  * b.m7  + a.m14 * b.m8  ,  a.m3  * b.m5  + a.m7  * b.m6  + a.m11 * b.m7  + a.m15 * b.m8  ,  a.m4  * b.m5  + a.m8  * b.m6  + a.m12  * b.m7  + a.m16 * b.m8,
							   a.m1  * b.m9  + a.m5  * b.m10 + a.m9  * b.m11 + a.m13 * b.m12 ,  a.m2  * b.m9  + a.m6  * b.m10 + a.m10  * b.m11 + a.m14 * b.m12 ,  a.m3  * b.m9  + a.m7  * b.m10 + a.m11 * b.m11 + a.m15 * b.m12 ,  a.m4  * b.m9  + a.m8  * b.m10 + a.m12  * b.m11 + a.m16 * b.m12,
							   a.m1  * b.m13 + a.m5  * b.m14 + a.m9  * b.m15 + a.m13 * b.m16 ,  a.m2  * b.m13 + a.m6  * b.m14 + a.m10  * b.m15 + a.m14 * b.m16 ,  a.m3  * b.m13 + a.m7  * b.m14 + a.m11 * b.m15 + a.m15 * b.m16 ,  a.m4  * b.m13 + a.m8  * b.m14 + a.m12  * b.m15 + a.m16 * b.m16);
		}
		public void SetRotateX(float fRad)
		{
			m5 = (float)Math.Cos(fRad);
			m6 = (float)-Math.Sin(fRad);
			m8 = (float)Math.Sin(fRad);
			m9 = (float)Math.Cos(fRad);
		}

		public void SetRotateY(float fRad)
		{
			m1 = (float)Math.Cos(fRad);
			m3 = (float)Math.Sin(fRad);
			m7 = (float)-Math.Sin(fRad);
			m9 = (float)Math.Cos(fRad);
		}

		public void SetRotateZ(float fRad)
		{
			m1 = (float)Math.Cos(fRad);
			m2 = (float)-Math.Sin(fRad);
			m4 = (float)Math.Sin(fRad);
			m5 = (float)Math.Cos(fRad);
		}

		//Extra helpful functions
		public void SetTranslation(float x, float y, float z)
		{
			m13 = x;
			m14 = y;
			m15 = z;
		}

		public void SetTranslation(Vector3 pos)
		{
			SetTranslation(pos.x, pos.y, pos.z);
		}

		public void SetScale(float x, float y, float z)
		{
			m1 = x;
			m6 = y;
			m11 = z;
		}

		public void SetScale(Vector3 scale)
		{
			SetScale(scale.x, scale.y, scale.z);
		}
	}
}