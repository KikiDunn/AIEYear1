using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	struct Matrix4
	{
		public float[] m;

		public Matrix4(bool bDefault = true)
		{
			m = new float[16];
			m[0] = 1;
			m[1] = 0;
			m[2] = 0;
			m[3] = 0;
			m[4] = 1;
			m[5] = 0;
			m[6] = 0;
			m[7] = 0;
			m[8] = 1;
		}

		public Matrix4(float m0, float m1, float m2, float m3, 
					   float m4, float m5, float m6, float m7,
					   float m8, float m9, float m10, float m11,
					   float m12, float m13, float m14, float m15)
		{
			m = new float[16];
			m[0] = m0;
			m[1] = m1;
			m[2] = m2;
			m[3] = m3;
			m[4] = m4;
			m[5] = m5;
			m[6] = m6;
			m[7] = m7;
			m[8] = m8;
			m[9] = m9;
			m[10] = m10;
			m[11] = m11;
			m[12] = m12;
			m[13] = m13;
			m[14] = m14;
			m[15] = m15;
		}

		public static Vector4 operator *(Matrix4 a, Vector4 b)
		{
			return new Vector4(a.m[0]  * b.x + a.m[4]  * b.y + a.m[8]  * b.z + a.m[12] * b.w,
							   a.m[1]  * b.x + a.m[5]  * b.y + a.m[9]  * b.z + a.m[13] * b.w,
							   a.m[2]  * b.x + a.m[6]  * b.y + a.m[10] * b.z + a.m[14] * b.w,
							   a.m[3]  * b.x + a.m[7]  * b.y + a.m[11] * b.z + a.m[15] * b.w);
		}

		public static Matrix4 operator *(Matrix4 a, Matrix3 b)
		{
			return new Matrix4(a.m[0]  * b.m[0]  + a.m[4]  * b.m[1]  + a.m[8]  * b.m[2]  + a.m[12] * b.m[3]  ,  a.m[0]  * b.m[0]  + a.m[4]  * b.m[1]  + a.m[8]  * b.m[2]  + a.m[12] * b.m[3]  ,  a.m[0]  * b.m[0]  + a.m[4]  * b.m[1]  + a.m[8]  * b.m[2]  + a.m[12] * b.m[3]  ,  a.m[0]  * b.m[0]  + a.m[4]  * b.m[1]  + a.m[8]  * b.m[2]  + a.m[12] * b.m[3],
							   a.m[0]  * b.m[4]  + a.m[4]  * b.m[5]  + a.m[8]  * b.m[6]  + a.m[12] * b.m[7]  ,  a.m[0]  * b.m[4]  + a.m[4]  * b.m[5]  + a.m[8]  * b.m[6]  + a.m[12] * b.m[7]  ,  a.m[0]  * b.m[4]  + a.m[4]  * b.m[5]  + a.m[8]  * b.m[6]  + a.m[12] * b.m[7]  ,  a.m[0]  * b.m[4]  + a.m[4]  * b.m[5]  + a.m[8]  * b.m[6]  + a.m[12] * b.m[7],
							   a.m[0]  * b.m[8]  + a.m[4]  * b.m[9]  + a.m[8]  * b.m[10] + a.m[12] * b.m[11] ,  a.m[0]  * b.m[8]  + a.m[4]  * b.m[9]  + a.m[8]  * b.m[10] + a.m[12] * b.m[11] ,  a.m[0]  * b.m[8]  + a.m[4]  * b.m[9]  + a.m[8]  * b.m[10] + a.m[12] * b.m[11] ,  a.m[0]  * b.m[8]  + a.m[4]  * b.m[9]  + a.m[8]  * b.m[10] + a.m[12] * b.m[11],
							   a.m[0]  * b.m[12] + a.m[4]  * b.m[13] + a.m[8]  * b.m[14] + a.m[12] * b.m[15] ,  a.m[0]  * b.m[12] + a.m[4]  * b.m[13] + a.m[8]  * b.m[14] + a.m[12] * b.m[15] ,  a.m[0]  * b.m[12] + a.m[4]  * b.m[13] + a.m[8]  * b.m[14] + a.m[12] * b.m[15] ,  a.m[0]  * b.m[12] + a.m[4]  * b.m[13] + a.m[8]  * b.m[14] + a.m[12] * b.m[15]);
		}
	}
}