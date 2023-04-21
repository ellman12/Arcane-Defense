using System.Collections;
using System.Collections.Generic;
using Audio;
using InputSystem;
using Player;
using Spells;
using UI;
using UnityEngine;

namespace Enemies
{
	public class Shrek : Enemy
	{
		[SerializeField] private float moveSpeed, playerStopDist, houseStopDist, playerChaseDistance, houseChaseDistance, attackCooldown, attackRange;
		[SerializeField] private List<Spell> spells;
		[SerializeField] private Audio.Audio appear;
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private float redColorDelta, posStatDelta, negStatDelta, statMultiplier;
		[SerializeField] private bool shadowShrek;
		
		private Transform player, house;
		private bool attackingHouse;

		public static Color color = Color.white;
		
		private void Start()
		{
			if (!shadowShrek) spriteRenderer.color = color;
			player = PlayerMovement.I.transform;
			house = PlayerHouse.I.transform;

			Health += posStatDelta * statMultiplier;
			moveSpeed += posStatDelta * statMultiplier;
			NegativeStatDelta(ref attackCooldown);
			
			AudioManager.I.PlayAudio(appear);
			
			StartCoroutine(Attack());
		}

		private void NegativeStatDelta(ref float stat)
		{
			float result = stat - negStatDelta;
			if (result >= 0) stat = result;
		}

		private void Update()
		{
			if (attackingHouse || !canMove || player == null || house == null) return;
		
			Vector2 playerDirection = player.position - transform.position;
			Vector2 houseDirection = house.position - transform.position;
			
			if (playerDirection.magnitude < playerChaseDistance && playerDirection.magnitude > playerStopDist)
				transform.Translate(playerDirection.normalized * (moveSpeed * Time.deltaTime));
			else if (houseDirection.magnitude < houseChaseDistance)
			{
				if (houseDirection.magnitude < houseStopDist)
					attackingHouse = true;
				else
					transform.Translate(houseDirection.normalized * (moveSpeed * Time.deltaTime));
			}
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
					newSpell.Initialize(true, transform, PlayerMovement.I.transform);
					yield return new WaitForSeconds(attackCooldown);
				}
				yield return null;
			}
			//ReSharper disable once IteratorNeverReturns
		}
		
		private void OnDestroy()
		{
			if (shadowShrek)
				Stats.I.shadowShrekKills++;
			else
				Stats.I.shrekKills++;

			Stats.I.UpdateStats();
			color.g -= redColorDelta;
			color.b -= redColorDelta;
		}
	}
}