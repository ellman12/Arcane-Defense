using Enemies;
using UnityEngine;

namespace Spells
{
	public class FreezeSpell : Spell
	{
		[SerializeField] private float duration;

		private Enemy[] enemies;

		private void Start()
		{
			enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
			foreach (Enemy enemy in enemies)
				enemy.canMove = false;
			
			Destroy(gameObject, duration);
		}

		private void OnDestroy()
		{
			foreach (Enemy enemy in enemies)
				enemy.canMove = true;
		}
	}
}