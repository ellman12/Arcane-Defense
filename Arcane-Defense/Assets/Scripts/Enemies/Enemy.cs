using Spells;
using UnityEngine;

namespace Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		public static bool canMove = true;
		
		[SerializeField] private int contactDamage;
		public int ContactDamage
		{
			get => contactDamage;
			private set => contactDamage = value;
		}

		[SerializeField] private float health;
		public float Health
		{
			get => health;
			set
			{
				health = value;
				if (health < 0)
				{
					Destroy(gameObject);
					GameManager.I.EnemiesAlive--;
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.CompareTag("Spell") && col.TryGetComponent(out Spell spell) && !spell.enemySpell)
			{
				Health -= spell.contactDamage;
				Destroy(spell.gameObject);
			}
		}
	}
}