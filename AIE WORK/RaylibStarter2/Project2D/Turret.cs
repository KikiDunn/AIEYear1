using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib.Raylib;
using MathLibrary;
namespace Project2D
{
	class Turret : GameObject
	{
		public Turret(string image) : base(image)
		{
		}
		public void rotate(float rad)
		{
			m_LocalTransform *= new Matrix3().Identity().SetRotateZ(rad);
		}
		public void translate(Vector2 position)
		{
			m_LocalTransform.m7 = position.x;
			m_LocalTransform.m8 = position.y;
		}
	}
}
