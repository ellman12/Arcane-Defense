using Audio;
using UnityEngine;

namespace Spells
{
	public abstract class Spell : MonoBehaviour
	{
		public bool enemySpell;

		public Transform start, target;

		protected Vector3 startPos, targetPos;
		
		public int contactDamage;

		public float knockbackForce, knockbackDuration;

		public Audio.Audio spellUse;
		
		public void Initialize(bool enemy, Transform s, Transform t)
		{
			enemySpell = enemy;
			
			if (start == null)
				start = s;
			
			if (target == null)
				target = t;
			
			AudioManager.I.PlaySound(spellUse);
		}
	}
}