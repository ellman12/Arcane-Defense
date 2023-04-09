﻿using System.Collections;
using System.Collections.Generic;
using InputSystem;
using Player;
using Spells;
using UnityEngine;

namespace Enemies
{
	public class Boss : Enemy
	{
		[SerializeField] private float moveSpeed, playerStopDist, houseStopDist, playerChaseDistance, houseChaseDistance, attackCooldown, defendCooldown, attackRange;
		[SerializeField] private List<Spell> spells;
		[SerializeField] private ShieldSpell shieldSpell;

		private Transform player, house;
		private bool attackingHouse;
		
		private void Start()
		{
			player = PlayerMovement.I.transform;
			house = PlayerHouse.I.transform;
			
			StartCoroutine(Attack());
			StartCoroutine(Defend());
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
		}

		private IEnumerator Defend()
		{
			while (true)
			{
				if (transform.childCount > 0) yield return null;
				
				ShieldSpell newSpell = Instantiate(shieldSpell, transform.position, Quaternion.identity);
				newSpell.Initialize(true, transform, null);
				yield return new WaitForSeconds(defendCooldown);
			}
		}
	}
}