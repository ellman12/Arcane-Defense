using System.Collections;
using Spells;
using UnityEngine;
using Utilities;

namespace Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		public float playerKnockbackForce;
		
		[HideInInspector] public bool canMove = true, targeted;
		private bool alive = true;

		[SerializeField] private new Rigidbody2D rigidbody;
		[SerializeField] private float knockbackResistance, lightningInvincibilityTime;
		[SerializeField] private int contactDamage;
		
		[SerializeField, ReadOnly] private bool invincible;

		public int ContactDamage
		{
			get => contactDamage;
			private set => contactDamage = value;
		}

		[SerializeField] private float health;
		private float Health
		{
			get => health;
			set
			{
				health = value;
				if (health <= 0 && alive)
				{
					alive = false;
					GameManager.I.EnemiesAlive--;
					Destroy(gameObject);
				}
			}
		}

		private void OnTriggerStay2D(Collider2D col)
		{
			if (col.TryGetComponent(out Spell spell) && !spell.enemySpell)
			{
				if (col.TryGetComponent(out ChainLightning chainLightning))
				{
					LoseHealth(chainLightning.contactDamage);

					if (Health <= 0) Destroy(spell.gameObject);
				}
				else
				{
					LoseHealth(spell.contactDamage);
					Destroy(spell.gameObject);

					float knockbackForce = spell.knockbackForce - knockbackResistance;
					if (knockbackForce <= 0) return;
					
					Vector2 knockbackDirection = (col.transform.position - transform.position).normalized;
					rigidbody.AddForce(-knockbackDirection * (spell.knockbackForce - knockbackResistance), ForceMode2D.Impulse);
					StartCoroutine(StopKnockback(spell.knockbackDuration));
				}
			}
		}
		
		private void LoseHealth(int amount)
		{
			if (invincible) return;

			Health -= amount;

			StartCoroutine(BecomeTemporarilyInvincible());
		}

		private IEnumerator BecomeTemporarilyInvincible()
		{
			invincible = true;
			yield return new WaitForSeconds(lightningInvincibilityTime);
			invincible = false;
		}

		private IEnumerator StopKnockback(float knockbackDuration)
		{
			yield return new WaitForSeconds(knockbackDuration);
			rigidbody.velocity = Vector2.zero;
		}
	}
}