using System.Collections;
using Player;
using Spells;
using UnityEngine;
using UnityEngine.UI;

namespace InputSystem
{
	public class SpellSlot : MonoBehaviour
	{
		[SerializeField] private Image slotIcon;

		[SerializeField] private Slider cooldownFill;

		[SerializeField] public SpellInfo spellInfo;

		private float cooldownRemaining;

		private void OnEnable()
		{
			cooldownFill.value = 0;
			if (spellInfo != null) slotIcon.sprite = spellInfo.spellIcon;
		}

		public void UseSpell()
		{
			if (cooldownRemaining > 0 || PlayerMana.I.Mana < spellInfo.mana || (spellInfo.name == "Water Shield" && PlayerMovement.I.transform.childCount >= 1) || (spellInfo.name == "House Water Shield" && PlayerHouse.I.transform.GetComponentInChildren<ShieldSpell>() != null)) return;
			Spell newSpell = Instantiate(spellInfo.spell, PlayerMovement.I.transform.position, Quaternion.identity);
			newSpell.Initialize(false, PlayerMovement.I.transform, null);
			
			PlayerMana.I.Mana -= spellInfo.mana;
			StartCoroutine(SpellCooldown());

			if (spellInfo.name == "Chain Lightning")
				newSpell.GetComponent<ChainLightning>().start = PlayerMovement.I.transform;
		}

		private IEnumerator SpellCooldown()
		{
			cooldownRemaining = spellInfo.cooldown;
			while (cooldownRemaining > 0)
			{
				cooldownRemaining -= Time.deltaTime;
				cooldownFill.value = cooldownRemaining / spellInfo.cooldown * 100;
				yield return null;
			}
			cooldownFill.value = 0;
		}
	}
}