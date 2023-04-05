using System.Runtime.CompilerServices;
using Enemies;
using InputSystem;
using UnityEngine;
using Utilities;

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
		public Transform start;
		private Transform target;
		private int spellNumber;

		private void Start()
		{
			target = FindClosestUniqueTarget(PlayerMovement.I.transform.position, targetSearchRadius, layerMask);
			if (targetsAttacked >= MAX_NUMBER_TARGETS || target == null) Destroy(gameObject);

			lineRenderer.positionCount = posCount;
			targetsAttacked++;
		}

		private void FixedUpdate()
		{
			try
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
			catch (MissingReferenceException)
			{
				Destroy(gameObject);
			}
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.TryGetComponent(out Enemy enemy) && !enemy.targeted)
			{
				enemy.canMove = false;
				enemy.targeted = true;
				var childChain = Instantiate(gameObject, target.position, Quaternion.identity);
				childChain.name = "Chain Lightning (Clone)";
				childChain.GetComponent<ChainLightning>().start = target;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Transform FindClosestUniqueTarget(Vector2 center, float radius, LayerMask targetLayer)
		{
			//ReSharper disable once Unity.PreferNonAllocApi
			Collider2D[] enemies = Physics2D.OverlapCircleAll(center, radius, targetLayer);
			float minDistance = Mathf.Infinity;
			Transform closestTarget = null;
			foreach (Collider2D enemy in enemies)
			{
				float distance = Vector2.Distance(center, enemy.transform.position);
				if (distance < minDistance && !enemy.GetComponent<Enemy>().targeted)
				{
					minDistance = distance;
					closestTarget = enemy.transform;
				}
			}

			return closestTarget;
		}

		private void OnDestroy()
		{
			targetsAttacked--;
			if (target != null)
			{
				Enemy enemy = target.GetComponent<Enemy>();
				enemy.canMove = true;
				enemy.targeted = false;
			}
		}
	}
}