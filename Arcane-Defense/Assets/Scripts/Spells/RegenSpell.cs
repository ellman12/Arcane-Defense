using System;
using System.Collections;
using Player;
using UnityEngine;

namespace Spells
{
	public class RegenSpell : Spell
	{
		[SerializeField] private int healthDelta;
		
		[SerializeField] private float regenRepeatRate, duration;

		private void Start()
		{
			Destroy(gameObject, duration);
			InvokeRepeating(nameof(IncreaseHealth), 0, regenRepeatRate);
		}

		private void IncreaseHealth() => PlayerHealth.I.Health += healthDelta;
	}
}