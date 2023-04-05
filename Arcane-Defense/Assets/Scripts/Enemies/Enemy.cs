using System.Collections;
using Spells;
using UnityEngine;

namespace Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		[HideInInspector] public bool canMove = true, targeted;

		[SerializeField] private new Rigidbody2D rigidbody;
		[SerializeField] private float knockbackResistance;
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

		private void OnTriggerStay2D(Collider2D col)
		{
			if (col.TryGetComponent(out Spell spell) && !spell.enemySpell)
			{
				if (col.TryGetComponent(out ChainLightning chainLightning))
				{
					Health -= chainLightning.contactDamage;

					if (Health <= 0) Destroy(spell.gameObject);
				}
				else
				{
					Health -= spell.contactDamage;
					Destroy(spell.gameObject);

					Vector2 knockbackDirection = (col.transform.position - transform.position).normalized;
					rigidbody.AddForce(-knockbackDirection * (spell.knockbackForce - knockbackResistance), ForceMode2D.Impulse);
					StartCoroutine(StopKnockback(spell.knockbackDuration));
				}
			}
		}

		private IEnumerator StopKnockback(float knockbackDuration)
		{
			yield return new WaitForSeconds(knockbackDuration);
			rigidbody.velocity = Vector2.zero;
		}
	}
}