using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	class CollisionManager
	{
		protected List<GameObject> m_Colliders = new List<GameObject>();
		public void Update()
		{
			for (int i = 0; i < m_Colliders.Count; i++)
			{
				for (int j = i + 1; j < m_Colliders.Count; j++)
				{
					GameObject collider = m_Colliders[i];
					GameObject collider2 = m_Colliders[j];
					if (collider.collidable && collider2.collidable)
					{
						if (BroadCollision(collider, collider2))
						{
							if (NarrowCollision(collider, collider2))
							{
								collider.OnCollision();
								collider2.OnCollision();
							}
						}
					}
				}
			}
		}
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
		private bool NarrowCollision(GameObject collider, GameObject collider2)
		{
			return true;
		}
		public void Add(GameObject collider)
		{
			m_Colliders.Add(collider);
		}
	}
}
