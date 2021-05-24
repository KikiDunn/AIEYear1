using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathLibrary;
namespace Project2D
{
	class GameObject
	{
		public Vector2 collider;
		public bool collidable = false;
		protected GameObject m_Parent = null;
		protected List<GameObject> m_Children = new List<GameObject>();
		protected Matrix3 m_LocalTransform;
		protected Matrix3 m_GlobalTransform;
		protected Texture2D m_Texture;
		protected Colour colour = new Colour(255, 255, 255, 255);
		public GameObject(string image)
		{
			m_Texture = LoadTextureFromImage(LoadImage(image));
			m_GlobalTransform = new Matrix3();
			m_LocalTransform = new Matrix3();
			m_LocalTransform.Identity();
			m_GlobalTransform.Identity();
		}
		public void Draw()
		{
			Renderer.DrawTexture(m_Texture, m_GlobalTransform, colour);
			foreach (GameObject child in m_Children)
			{
				child.Draw();
			}
			//DrawTextureEx(m_Texture, Renderer.ToRLVector2(new Vector2(0, 0)), 0, 1, RLColor.WHITE);
		}
		public void AddParent(GameObject parent)
		{
			m_Parent = parent;
		}
		public void AdoptChild(GameObject child)
		{
			m_Children.Add(child);
			child.AddParent(this);
		}
		public void DisownChild(GameObject child)
		{
			m_Children.Remove(child);
			child.AddParent(null);
		}
		public virtual void Update(float fDeltaTime)
		{
			foreach (GameObject child in m_Children)
			{
				child.Update(fDeltaTime);
			}
		}
		public void UpdateTransforms()
		{
			if(m_Parent != null)
			{
				m_GlobalTransform = m_Parent.m_GlobalTransform * m_LocalTransform;
			}
			else
			{
				m_GlobalTransform = m_LocalTransform;
			}
			foreach(GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}
		}
		public Vector2 GetPosition()
		{
			return new Vector2(m_LocalTransform.m7, m_LocalTransform.m8);
		}
		public virtual void OnCollision()
		{

		}
		public void SetPosition(Vector2 pos)
		{
			m_LocalTransform.m7 = pos.x;
			m_LocalTransform.m8 = pos.y;
		}
	}
}
