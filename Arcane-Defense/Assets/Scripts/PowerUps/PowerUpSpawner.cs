using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowerUps
{
	public class PowerUpSpawner : Singleton<PowerUpSpawner>
	{
		[SerializeField] private Vector3 spawnOffset;
		[SerializeField] private List<PowerUp> powerUps;

		private void Start() => GameManager.I.RoundAdvance += SpawnPowerUp;

		private void SpawnPowerUp(object sender, EventArgs eventArgs)
		{
			Instantiate(powerUps[Random.Range(0, powerUps.Count)], PlayerHouse.I.transform.position + spawnOffset, Quaternion.identity);
		}
	}
}