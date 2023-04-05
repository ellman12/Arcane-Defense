using System.Collections;
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
			slotIcon.sprite = spellInfo.spellIcon;
		}

		public void UseSpell()
		{
			if (cooldownRemaining > 0) return;
			GameObject newSpell = Instantiate(spellInfo.spell, PlayerMovement.I.transform.position, Quaternion.identity);
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