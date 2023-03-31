using UnityEngine;
using Utilities;

namespace Player
{
	public class PlayerHouse : Singleton<PlayerHouse>
	{
		[SerializeField, ReadOnly] private int health, maxHealth;
		[SerializeField] private StatBar healthBar;

		private int Health
		{
			get => health;
			set
			{
				health = value;
				healthBar.SetValue(health);
				if (health <= 0)
					Destroy(gameObject);
			}
		}

		private int MaxHealth
		{
			get => maxHealth;
			set
			{
				maxHealth = value;
				healthBar.SetMaxValue(maxHealth);
			}
		}

		private new void Awake()
		{
			MaxHealth = Health = 100;
			base.Awake();
		}
	}
}