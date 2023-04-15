using System.Collections;
using Enemies;
using InputSystem;
using Spells;
using UnityEngine;
using Utilities;

namespace Player
{
	public class PlayerHouse : Singleton<PlayerHouse>
	{
		[SerializeField] private float invincibilityDuration;
		[SerializeField] private StatBar healthBar;
		[SerializeField] private GameObject gameOverScreen;
		[SerializeField] private int maxHealth;

		[SerializeField, ReadOnly] private int health;
		[SerializeField, ReadOnly] private bool invincible;

		public int Health
		{
			get => health;
			set
			{
				health = value;
				healthBar.SetValue(health);
				if (health <= 0)
				{
					Destroy(gameObject);
					gameOverScreen.SetActive(true);
					Time.timeScale = 0;
					InputManager.I.PlayerInput.Disable();
				}
			}
		}

		public int MaxHealth
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
			base.Awake();
			Health = MaxHealth;
			healthBar.SetMaxValue(MaxHealth);
		}

		private void OnCollisionStay2D(Collision2D col)
		{
			if (col.gameObject.CompareTag("Enemy"))
				LoseHealth(col.gameObject.GetComponent<Enemy>().ContactDamage);
			else if (col.gameObject.TryGetComponent(out Spell spell) && spell.enemySpell)
				LoseHealth(spell.contactDamage);
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
			yield return new WaitForSeconds(invincibilityDuration);
			invincible = false;
		}

		public void RestoreHealth() => Health = MaxHealth;
	}
}