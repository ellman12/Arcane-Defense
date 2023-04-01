using System;
using System.Collections;
using Enemies;
using UnityEngine;
using Utilities;

namespace Player
{
	public class PlayerHouse : Singleton<PlayerHouse>
	{
		[SerializeField] private float invincibilityDuration, invincibilityDeltaTime;
		[SerializeField] private StatBar healthBar;
		[SerializeField] private SpriteRenderer spriteRenderer;

		[SerializeField, ReadOnly] private int health, maxHealth;
		[SerializeField, ReadOnly] private bool invincible;

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

		private void OnTriggerStay2D(Collider2D col)
		{
			Debug.Log(col.tag);
			if (col.CompareTag("Enemy"))
				LoseHealth(col.GetComponent<Enemy>().ContactDamage);
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

			for (float i = 0; i < invincibilityDuration; i += invincibilityDeltaTime)
			{
				spriteRenderer.enabled = !spriteRenderer.enabled;
				yield return new WaitForSeconds(invincibilityDeltaTime);
			}

			invincible = false;
			spriteRenderer.enabled = true;
		}
	}
}