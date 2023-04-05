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
			GameObject parent = GameObject.Find(parentName);
			transform.position = parent.transform.position;
			transform.parent = parent.transform;
			
			Destroy(gameObject, duration);
		}
	}
}