using InputSystem;
using UnityEngine;

namespace Enemies
{
	public class SwordEnemy : Enemy
	{
		[SerializeField] private float moveSpeed, stoppingDistance;

		private Transform player, playerHouse;

		private void Start()
		{
			player = PlayerMovement.I.transform;
		}

		private void Update()
		{
			Vector2 direction = player.position - transform.position;

			if (direction.magnitude > stoppingDistance)
				transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime));
		}
	}
}