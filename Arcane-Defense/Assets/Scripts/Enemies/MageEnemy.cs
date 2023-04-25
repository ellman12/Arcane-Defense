using System.Collections;
using System.Collections.Generic;
using InputSystem;
using Spells;
using UI;
using UnityEngine;

namespace Enemies
{
	public class MageEnemy : Enemy
	{
		[SerializeField] private float moveSpeed, stoppingDistance, attackCooldown, playerInRangeCheckCooldown, attackRange;
		[SerializeField] private List<Spell> spells;

		private Transform player, playerHouse;

		private void Start()
		{
			player = PlayerMovement.I.transform;

			StartCoroutine(Attack());
		}

		private void Update()
		{
			if (!canMove || player == null) return;
			
			Vector2 direction = player.position - transform.position;

			if (direction.magnitude > stoppingDistance)
				transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime));
		}

		private IEnumerator Attack()
		{
			while (true)
			{
				Vector2 direction = player.position - transform.position;

				if (direction.magnitude <= attackRange)
				{
					int index = Random.Range(0, spells.Count);
					Spell newSpell = Instantiate(spells[index], transform.position, Quaternion.identity);
					newSpell.contactDamage *= 3;
					newSpell.Initialize(true, transform, PlayerMovement.I.transform);
					yield return new WaitForSeconds(attackCooldown);
				}
				yield return new WaitForSeconds(playerInRangeCheckCooldown);
			}
		}
		
		private void OnDestroy()
		{
			Stats.I.mageEnemyKills++;
			Stats.I.UpdateStats();
		}
	}
}