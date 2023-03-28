using UnityEngine;

namespace Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		private float health;

		public float Health
		{
			get => health;
			set
			{
				health = value;
				if (health < 0)
					Destroy(gameObject);
			}
		}
	}
}