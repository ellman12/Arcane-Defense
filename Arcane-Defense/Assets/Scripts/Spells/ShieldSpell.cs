using InputSystem;
using UnityEngine;

namespace Spells
{
	public class ShieldSpell : Spell
	{
		[SerializeField] private float duration;

		private float remainingDuration;
		
		private void Start()
		{
			transform.position = PlayerMovement.I.transform.position;
			transform.parent = PlayerMovement.I.transform;
			
			Destroy(gameObject, duration);
		}
	}
}