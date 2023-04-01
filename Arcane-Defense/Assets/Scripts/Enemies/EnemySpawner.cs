using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Enemies
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private float spawnRepeatRate;
		[SerializeField] private List<Enemy> enemies;

		private new BoxCollider2D collider;
		private Vector2 bottomLeft, topLeft, bottomRight;

		private void Start()
		{
			collider = GetComponent<BoxCollider2D>();
			bottomLeft = new Vector2(collider.bounds.min.x, collider.bounds.min.y);
			topLeft = new Vector2(collider.bounds.min.x, collider.bounds.max.y);
			bottomRight = new Vector2(collider.bounds.max.x, collider.bounds.min.y);

			InvokeRepeating(nameof(EnemySpawning), 0, spawnRepeatRate);
		}

		private void EnemySpawning()
		{
			if (GameManager.I.RemainingAmountToSpawn <= 0) return;

			int index = Random.Range(0, enemies.Count);
			var newEnemy = PrefabUtility.InstantiatePrefab(enemies[index]) as Enemy;
			newEnemy!.transform.position = GetNewEnemyStartPos();
			GameManager.I.RemainingAmountToSpawn--;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Vector2 GetNewEnemyStartPos() => new(Random.Range(bottomLeft.x, bottomRight.x), Random.Range(bottomLeft.y, topLeft.y));
	}
}