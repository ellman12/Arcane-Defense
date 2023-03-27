using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private float spawnRepeatRate;
		
		private new BoxCollider2D collider;
		private Vector2 bottomLeft, topLeft, topRight, bottomRight;

		private void Start()
		{
			collider = GetComponent<BoxCollider2D>();
			bottomLeft = new Vector2(collider.bounds.min.x, collider.bounds.min.y);
			topLeft = new Vector2(collider.bounds.min.x, collider.bounds.max.y);
			topRight = new Vector2(collider.bounds.max.x, collider.bounds.max.y);
			bottomRight = new Vector2(collider.bounds.max.x, collider.bounds.min.y);
			
			InvokeRepeating(nameof(EnemySpawning), 0, spawnRepeatRate);
		}

		private void EnemySpawning()
		{
			GetNewEnemyStartPos();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Vector2 GetNewEnemyStartPos() => new(Random.Range(bottomLeft.x, bottomRight.x), Random.Range(bottomLeft.y, topLeft.y));
	}
}