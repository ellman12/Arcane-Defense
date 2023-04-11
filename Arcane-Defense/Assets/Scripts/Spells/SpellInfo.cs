using UnityEngine;

namespace Spells
{
	[CreateAssetMenu(fileName = "SpellInfo", menuName = "SpellInfo", order = 0)]
	public class SpellInfo : ScriptableObject
	{
		public Sprite spellIcon;

		public float cooldown;

		public int mana;

		public string info;
		
		public Spell spell;
	}
}