using System;
using System.Collections;
using Enemies;
using UnityEngine;
using Utilities;

namespace Player
{
	public class PlayerHealth : Singleton<PlayerHealth>
	{
		[SerializeField] private float invincibilityDuration, invincibilityDeltaTime;
		[SerializeField] private StatBar healthBar;
		
		[SerializeField, ReadOnly] private int health, maxHealth;
		[SerializeField, ReadOnly] private bool invincible;

		public int Health
		{
			get => health;
			set
			{
				health = value;
				if (health > MaxHealth)
					health = MaxHealth;
				
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

		private void Start()
		{
			Health = MaxHealth = 100;
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Enemy"))
				LoseHealth(collision.gameObject.GetComponent<Enemy>().ContactDamage);
		}

		public void LoseHealth(int amount)
		{
			if (invincible) return;

			Health -= amount;

			StartCoroutine(BecomeTemporarilyInvincible());
		}

		private IEnumerator BecomeTemporarilyInvincible()
		{
			invincible = true;

			for (float i = 0; i < invincibilityDuration; i += invincibilityDeltaTime)
			{
				transform.localScale = transform.localScale == Vector3.one ? Vector3.zero : Vector3.one;
				yield return new WaitForSeconds(invincibilityDeltaTime);
			}

			invincible = false;
			transform.localScale = Vector3.one;
		}
	}
}