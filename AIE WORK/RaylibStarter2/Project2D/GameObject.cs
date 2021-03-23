﻿using System;
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
		protected Colour colour = new Colour(255, 255, 255, 255);
		public GameObject(string image)
		{
			m_Texture = LoadTextureFromImage(LoadImage(image));
			m_GlobalTransform = new Matrix3();
			m_LocalTransform = new Matrix3();
			m_LocalTransform.Identity();
			m_GlobalTransform.Identity();
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
			foreach (GameObject child in m_Children)
			{
				child.draw();
			}
			//DrawTextureEx(m_Texture, Renderer.ToRLVector2(new Vector2(0, 0)), 0, 1, RLColor.WHITE);
		}
		public void addParent(GameObject parent)
		{
			m_Parent = parent;
		}
		public void adoptChild(GameObject child)
		{
			m_Children.Add(child);
			child.addParent(this);
		}
		public void disownChild(GameObject child)
		{
			m_Children.Remove(child);
			child.addParent(null);
		}
		public virtual void Update(float fDeltaTime)
		{
			foreach (GameObject child in m_Children)
			{
				child.Update(fDeltaTime);
			}
		}
		public void updateTransforms()
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
				child.updateTransforms();
			}
		}
	}
}