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
		protected GameObject m_Parent = null;
		protected List<GameObject> m_Children = new List<GameObject>();
		protected Matrix3 m_LocalTransform;
		protected Matrix3 m_GlobalTransform;
		protected Texture2D m_Texture;
		protected Colour colour = new Colour(1, 1, 1, 1);
		public GameObject(string image)
		{
			m_Texture = LoadTextureFromImage(LoadImage(image));
		}
		public void UpdateTransforms()
		{
			if (m_Parent != null)
				m_GlobalTransform = m_Parent.m_GlobalTransform * m_LocalTransform;
			else
				m_GlobalTransform = m_LocalTransform;

			foreach (GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}
		}
		public void draw()
		{
			Renderer.DrawTexture(m_Texture, m_GlobalTransform, colour);
		}
		public void addParent()
		{

		}
		public void adoptChild()
		{

		}
		public void disownChild()
		{

		}
	}
}
