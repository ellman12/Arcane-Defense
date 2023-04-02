using Enemies;
using UnityEngine;

namespace Spells
{
	public class FreezeSpell : Spell
	{
		[SerializeField] private float duration;

		private void Start()
		{
			Enemy.canMove = false;
			Destroy(gameObject, duration);
		}

		private void OnDestroy()
		{
			Enemy.canMove = true;
		}
	}
}