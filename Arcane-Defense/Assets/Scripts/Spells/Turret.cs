using System;
using System.Collections;
using UnityEngine;
using Utilities;

namespace Spells
{
	public class Turret : Spell
	{
		[SerializeField] private float targetingRange, shotCooldown, enemyInRangeCheckCooldown;

		[SerializeField] private Spell spell;

		[SerializeField] private LayerMask layerMask;

		[SerializeField, ReadOnly] private Transform currentTarget;

		private readonly Collider2D[] targets = new Collider2D[250];

		private void Start()
		{
			StartCoroutine(Target());
			StartCoroutine(AttackTarget());
		}

		private Transform GetClosestTarget()
		{
			int amount = Physics2D.OverlapCircleNonAlloc(transform.position, targetingRange, targets, layerMask);
			if (amount == 0) return null;

			Transform closestTarget = null;
			float closestDistance = Mathf.Infinity;
			for (int i = 0; i < amount; i++)
			{
				Collider2D target = targets[i];
				float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
				if (distanceToTarget < closestDistance)
				{
					closestDistance = distanceToTarget;
					closestTarget = target.transform;
				}
			}

			return closestTarget;
		}

		private IEnumerator Target()
		{
			while (true)
			{
				currentTarget = GetClosestTarget();

				Vector3 targetPos = currentTarget.transform.position;
				Vector3 spellPos = Camera.main!.WorldToScreenPoint(transform.position);
				targetPos.x -= spellPos.x;
				targetPos.y -= spellPos.y;
				float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
				
				yield return new WaitForSeconds(shotCooldown);
			}
		}

		private IEnumerator AttackTarget()
		{
			while (true)
			{
				var newSpell = Instantiate(spell, transform.position, Quaternion.identity) as LinearTravelSpell ?? throw new NullReferenceException();
				newSpell.start = transform;
				newSpell.target = currentTarget;
				yield return new WaitForSeconds(shotCooldown);
			}
		}
	}
}