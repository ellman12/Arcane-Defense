using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

		private const int MAX_NUMBER_TARGETS = 4;
		private static int targetsAttacked;
		private Transform start, target;
		public static readonly HashSet<Transform> targets = new(MAX_NUMBER_TARGETS);

		private void Start()
		{
			target = FindClosestUniqueTarget(PlayerMovement.I.transform.position, targetSearchRadius, layerMask);
			if (targetsAttacked >= MAX_NUMBER_TARGETS || target == null) Destroy(gameObject);

			start = targets.Count > 0 ? targets.Last() : PlayerMovement.I.transform;
	
			lineRenderer.positionCount = posCount;
		}

		private void FixedUpdate()
		{
			for (int i = 1; i < posCount - 1; i++)
			{
				Vector2 position = Vector2.Lerp(start.position, target.transform.position, (float) i / posCount);
				position.x += Random.Range(xDeltaMin, xDeltaMax);
				position.y += Random.Range(yDeltaMin, yDeltaMax);
				lineRenderer.SetPosition(i, position);
			}

			lineRenderer.SetPosition(0, start.position);
			lineRenderer.SetPosition(posCount - 1, target.transform.position);
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (targetsAttacked < MAX_NUMBER_TARGETS && !targets.Contains(col.transform))
			{
				targetsAttacked++;
				target = col.transform;
				targets.Add(target);
				Instantiate(gameObject, target.position, Quaternion.identity);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Transform FindClosestUniqueTarget(Vector2 center, float radius, LayerMask targetLayer)
		{
			//ReSharper disable once Unity.PreferNonAllocApi
			Collider2D[] enemies = Physics2D.OverlapCircleAll(center, radius, targetLayer);
			float minDistance = Mathf.Infinity;
			Transform closestTarget = null;
			foreach (Collider2D enemy in enemies.Where(target => !targets.Contains(target.transform)))
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