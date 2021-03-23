using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib.Raylib;
using MathLibrary;
namespace Project2D
{
	class Tank : GameObject
	{
		private Vector2 velocity;
		private Vector2 acceleration;
		private float force = 100000;
		private float mass = 15000;
		private float circularVelocity;
		private float circularAcceleration;
		public Tank(string image) : base(image)
		{
			velocity = new Vector2();
			acceleration = new Vector2();
			circularVelocity = 0;
			circularAcceleration = 0;
		}
		public override void Update(float fDeltaTime)
		{
			acceleration = new Vector2(0, 0);
			circularAcceleration = 0;
			if (IsKeyDown(Raylib.KeyboardKey.KEY_W)){
				acceleration = new Vector2(-m_LocalTransform.m4, -m_LocalTransform.m5).Normalise();
			}
			if (IsKeyDown(Raylib.KeyboardKey.KEY_A)){
				circularAcceleration = -1;
			}
			if (IsKeyDown(Raylib.KeyboardKey.KEY_S))
			{
				acceleration = new Vector2(m_LocalTransform.m4, m_LocalTransform.m5).Normalise();
			}
			if (IsKeyDown(Raylib.KeyboardKey.KEY_D)){
				circularAcceleration = 1;
			}
			
			velocity = velocity + acceleration * (force/mass) * fDeltaTime;
			circularVelocity = circularVelocity + circularAcceleration * fDeltaTime * 0.0001f;
			m_LocalTransform *= new Matrix3().Identity().SetRotateZ(circularVelocity);
			m_LocalTransform.m7 = m_LocalTransform.m7 + velocity.x * 11 * fDeltaTime;
			m_LocalTransform.m8 = m_LocalTransform.m8 + velocity.y * 11 * fDeltaTime;
		}
	}
}
