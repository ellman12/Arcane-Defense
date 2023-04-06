using UnityEngine;

namespace Spells
{
	public class ShieldSpell : Spell
	{
		[SerializeField] private string parentName;
		[SerializeField] private float duration;

		private float remainingDuration;
		
		private void Start()
		{
			if (target == null)
				target = GameObject.Find(parentName).transform;

			transform.position = target.transform.position;
			transform.parent = target.transform;
			
			Destroy(gameObject, duration);
		}
	}
}