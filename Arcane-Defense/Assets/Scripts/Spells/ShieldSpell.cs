using System;
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
			if (!String.IsNullOrWhiteSpace(parentName))
				start = GameObject.Find(parentName).transform;

			transform.position = start.transform.position;
			transform.parent = start.transform;
			
			Destroy(gameObject, duration);
		}

		private void Update() => transform.position = start.transform.position;

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