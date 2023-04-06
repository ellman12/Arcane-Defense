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
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = -MainCamera.I.camera.transform.position.z;
			Vector3 worldPosition = MainCamera.I.camera.ScreenToWorldPoint(mousePosition);
			transform.position = worldPosition;
			
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
				float distanceToTarget = Vector2.Distance(transform.position, targets[i].transform.position);
				if (distanceToTarget < closestDistance)
				{
					closestDistance = distanceToTarget;
					closestTarget = targets[i].transform;
				}
			}

			return closestTarget;
		}

		private IEnumerator Target()
		{
			while (true)
			{
				currentTarget = GetClosestTarget();
				if (currentTarget == null)
				{
					yield return new WaitForSeconds(enemyInRangeCheckCooldown);
					continue;
				}
				
				Vector3 direction = currentTarget.position - transform.position;
				float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				
				yield return new WaitForSeconds(0.1f);
			}
		}

		private IEnumerator AttackTarget()
		{
			while (true)
			{
				if (currentTarget == null)
				{
					yield return new WaitForSeconds(enemyInRangeCheckCooldown);
					continue;
				}
				
				var newSpell = Instantiate(spell, transform.position, Quaternion.identity) as LinearTravelSpell ?? throw new NullReferenceException();
				newSpell.target = currentTarget;
				newSpell.speed *= 2;
				yield return new WaitForSeconds(shotCooldown);
			}
		}
	}
}