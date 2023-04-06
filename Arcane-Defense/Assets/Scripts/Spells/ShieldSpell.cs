using UnityEngine;

namespace Spells
{
	public class ShieldSpell : Spell
	{
		[SerializeField] private string parentName;
		[SerializeField] private float duration;
		[SerializeField] private int health;
		private int Health
		{
			get => health;
			set
			{
				health = value;
				if (health <= 0)
					Destroy(gameObject);
			}
		}

		private float remainingDuration;
		
		private void Start()
		{
			if (target == null)
				target = GameObject.Find(parentName).transform;

			transform.position = target.transform.position;
			transform.parent = target.transform;
			
			Destroy(gameObject, duration);
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.TryGetComponent(out Spell other) && enemySpell != other.enemySpell)
			{
				Health--;
				Destroy(other.gameObject);
			}
		}
	}
}