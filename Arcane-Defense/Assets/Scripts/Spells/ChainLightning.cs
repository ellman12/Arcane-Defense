using System.Collections.Generic;
using InputSystem;
using UnityEngine;

namespace Spells
{
	public class ChainLightning : Spell
	{
		[SerializeField] private LineRenderer lineRenderer;

		[SerializeField] private float targetSearchRadius, xDeltaMin, xDeltaMax, yDeltaMin, yDeltaMax;

		[SerializeField] private int posCount;

		[SerializeField] private LayerMask layerMask;

		private const int MAX_NUMBER_TARGETS = 3;
		private static int targetsAttacked;
		private Transform target;
		private static readonly HashSet<Transform> targets = new(MAX_NUMBER_TARGETS);

		private void Start()
		{
			lineRenderer.positionCount = posCount;
			target = FindClosestTarget(PlayerMovement.I.transform.position, targetSearchRadius, layerMask);
		}

		private void FixedUpdate()
		{
			for (int i = 1; i < posCount - 1; i++)
			{
				Vector2 position = Vector2.Lerp(PlayerMovement.I.transform.position, target.transform.position, (float) i / posCount);
				position.x += Random.Range(xDeltaMin, xDeltaMax);
				position.y += Random.Range(yDeltaMin, yDeltaMax);
				lineRenderer.SetPosition(i, position);
			}

			lineRenderer.SetPosition(0, PlayerMovement.I.transform.position);
			lineRenderer.SetPosition(posCount - 1, target.transform.position);
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			// if (targetsAttacked < MAX_NUMBER_TARGETS && !targets.Contains(col.transform))
			// {
			// 	targetsAttacked--;
			// 	target = col.transform;
			// 	targets.Add(target);
			// 	Instantiate(gameObject, target.position, Quaternion.identity);
			// }
		}

		private static Transform FindClosestTarget(Vector2 center, float radius, LayerMask targetLayer)
		{
			//ReSharper disable once Unity.PreferNonAllocApi
			Collider2D[] enemies = Physics2D.OverlapCircleAll(center, radius, targetLayer);
			float minDistance = Mathf.Infinity;
			Transform closestTarget = null;
			foreach (Collider2D enemy in enemies)
			{
				float distance = Vector2.Distance(center, enemy.transform.position);
				if (distance < minDistance)
				{
					minDistance = distance;
					closestTarget = enemy.transform;
				}
			}
			return closestTarget;
		}
	}
}