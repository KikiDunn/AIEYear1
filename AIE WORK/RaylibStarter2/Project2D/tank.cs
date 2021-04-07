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
		GameObject turret;
		Turret node;
		private Vector2 velocity;
		private Vector2 acceleration;
		private Vector2 prevPos;
		private float force = 1000000;
		private float mass = 15000;
		private float circularVelocity;
		private float circularAcceleration;
		private float drag = 0.0005f;
		private float dragCoefficient = 0.0000000001f;
		public Tank(string image) : base(image)
		{
			velocity = new Vector2(0, 0);
			acceleration = new Vector2();
			circularVelocity = 0;
			circularAcceleration = 0;
			turret = new GameObject("../Images/turret.png");
			node = new Turret("");
			this.AdoptChild(node);
			node.AdoptChild(turret);
			node.Translate(new Vector2(0, -23));
			collidable = true;
			collider = new Vector2(m_Texture.height/2, m_Texture.height/2);
		}
		public override void Update(float fDeltaTime)
		{
			prevPos = new Vector2(m_LocalTransform.m7, m_LocalTransform.m8);
			acceleration = velocity * -drag;
			circularAcceleration = circularVelocity * -20000*drag;
			if (IsKeyDown(Raylib.KeyboardKey.KEY_W))
			{
				acceleration += new Vector2(-m_LocalTransform.m4, -m_LocalTransform.m5).Normalise();
			}
			if (IsKeyDown(Raylib.KeyboardKey.KEY_A))
			{
				circularAcceleration += -1;
			}
			if (IsKeyDown(Raylib.KeyboardKey.KEY_S))
			{
				acceleration += new Vector2(m_LocalTransform.m4, m_LocalTransform.m5).Normalise();
			}
			if (IsKeyDown(Raylib.KeyboardKey.KEY_D))
			{
				circularAcceleration += 1;
			}
			if (IsKeyDown(Raylib.KeyboardKey.KEY_Q))
			{
				node.Rotate((float)(-360 * Math.PI/180 * fDeltaTime));
			}
			if (IsKeyDown(Raylib.KeyboardKey.KEY_E))
			{
				node.Rotate((float)(360 * Math.PI / 180 * fDeltaTime));
			}
			velocity = velocity + acceleration * (force/mass) * fDeltaTime;

			if (circularVelocity > 0.0002f)
			{
				circularVelocity = 0.0002f;
			}
			if (circularVelocity < -0.0002f)
			{
				circularVelocity = -0.0002f;
			}
			circularVelocity = circularVelocity + circularAcceleration * fDeltaTime * 0.0001f * (force / mass);
			m_LocalTransform *= new Matrix3().Identity().SetRotateZ(circularVelocity);

			m_LocalTransform.m7 = m_LocalTransform.m7 + velocity.x * 11 * fDeltaTime;
			m_LocalTransform.m8 = m_LocalTransform.m8 + velocity.y * 11 * fDeltaTime;
		}
		public override void OnCollision()
		{
			m_LocalTransform.m7 = prevPos.x;
			m_LocalTransform.m8 = prevPos.y;
			velocity = new Vector2(-velocity.x *0.5f, -velocity.y*0.5f);
		}
	}
}
