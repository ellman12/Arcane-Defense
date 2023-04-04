using Enemies;
using InputSystem;
using UnityEngine;

namespace Spells
{
	public class ChainLightning : Spell
	{
		[SerializeField] private LineRenderer lineRenderer;

		[SerializeField] private float xDeltaMin, xDeltaMax, yDeltaMin, yDeltaMax;

		[SerializeField] private int posCount;

		[SerializeField] private Enemy target;

		private void Start()
		{
			lineRenderer.positionCount = posCount;
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
	}
}