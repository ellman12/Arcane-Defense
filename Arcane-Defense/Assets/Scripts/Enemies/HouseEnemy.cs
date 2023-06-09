﻿using InputSystem;
using Player;
using UI;
using UnityEngine;

namespace Enemies
{
	public class HouseEnemy : Enemy
	{
		[SerializeField] private float houseContactDamage, moveSpeed, playerStopDist, houseStopDist, playerChaseDistance, houseChaseDistance;

		private Transform player, house;
		private bool attackingHouse;

		private void Start()
		{
			player = PlayerMovement.I.transform;
			house = PlayerHouse.I.transform;
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
		
		private void OnDestroy()
		{
			Stats.I.houseEnemyKills++;
			Stats.I.UpdateStats();
		}
	}
}