using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	class CollisionManager
	{
		//List of collision objects
		protected List<GameObject> m_Colliders = new List<GameObject>();
		public void Update()
		{
			//Loops through all possible collisions
			for (int i = 0; i < m_Colliders.Count; i++)
			{
				for (int j = i + 1; j < m_Colliders.Count; j++)
				{
					GameObject collider = m_Colliders[i];
					GameObject collider2 = m_Colliders[j];
					//checks if the colliders are set to collidable
					if (collider.collidable && collider2.collidable)
					{
						//runs the collision check function on the two colliders
						if (BroadCollision(collider, collider2))
						{
							if (NarrowCollision(collider, collider2))
							{
								//calls each colliders function that determines what happens when it collides
								collider.OnCollision();
								collider2.OnCollision();
							}
						}
					}
				}
			}
		}
		//Collision check that checks if two colliders are overlapping on the x and y axis
		private bool BroadCollision(GameObject collider, GameObject collider2)
		{
			float min1x = collider.GetPosition().x - collider.collider.x;
			float max1x= collider.GetPosition().x + collider.collider.x;
			float min1y = collider.GetPosition().y - collider.collider.y;
			float max1y = collider.GetPosition().y + collider.collider.y;
			float min2x = collider2.GetPosition().x - collider2.collider.x;
			float max2x = collider2.GetPosition().x + collider2.collider.x;
			float min2y = collider2.GetPosition().y - collider2.collider.y;
			float max2y = collider2.GetPosition().y + collider2.collider.y;
			if (((min1x < max2x) && (max1x > min2x)) && ((min1y < max2y) && (max1y > min2y)))
			{
				return true;
			}
			else
			{
				return false;
			}
			
		}
		//place holder for a better collision check
		private bool NarrowCollision(GameObject collider, GameObject collider2)
		{
			return true;
		}
		//adds an object to the list of colliders
		public void Add(GameObject collider)
		{
			m_Colliders.Add(collider);
		}
	}
}
