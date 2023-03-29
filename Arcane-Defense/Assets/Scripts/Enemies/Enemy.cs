using UnityEngine;

namespace Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField]
		private int contactDamage;
		public int ContactDamage
		{
			get => contactDamage;
			private set => contactDamage = value;
		}
		
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