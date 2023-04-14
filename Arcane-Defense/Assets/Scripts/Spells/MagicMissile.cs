﻿using System.Collections;
using InputSystem;
using UnityEngine;

namespace Spells
{
	public class MagicMissile : Spell
	{
		[SerializeField] private float targetingRange, speed;
		
		[SerializeField] private LayerMask layerMask;

		private void Start()
		{
			target = GetClosestTarget();
			StartCoroutine(target == null ? MoveForward() : MoveTowardsTarget());
			Destroy(gameObject, 30);
		}

		private IEnumerator MoveForward()
		{
			RotateToPoint();
			while (true)
			{
				transform.position += transform.right * (speed * Time.deltaTime);
				yield return null;
			}
			//ReSharper disable once IteratorNeverReturns
		}

		private IEnumerator MoveTowardsTarget()
		{
			while (true)
			{
				RotateToPoint();
				
				Vector3 targetDirection = target.position - transform.position;
				transform.position += targetDirection.normalized * speed * Time.deltaTime;
				
				yield return null;
			}
			//ReSharper disable once IteratorNeverReturns
		}

		private Transform GetClosestTarget()
		{
			//ReSharper disable once Unity.PreferNonAllocApi
			Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, targetingRange, layerMask);
			if (enemies == null) return null;

			Transform closestTarget = null;
			float closestDistance = Mathf.Infinity;
			foreach (Collider2D enemy in enemies)
			{
				float distanceToTarget = Vector2.Distance(transform.position, enemy.transform.position);
				if (distanceToTarget < closestDistance)
				{
					closestDistance = distanceToTarget;
					closestTarget = enemy.transform;
				}
			}

			return closestTarget;
		}

		private void RotateToPoint()
		{
			startPos = transform.position;
			targetPos = target == null ? InputManager.I.CursorPos : target.position;

			targetPos.x -= startPos.x;
			targetPos.y -= startPos.y;
			float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		}
	}
}