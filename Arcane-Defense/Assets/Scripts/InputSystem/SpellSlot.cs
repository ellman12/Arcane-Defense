using System.Collections;
using Player;
using Spells;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InputSystem
{
	public class SpellSlot : MonoBehaviour, IPointerClickHandler
	{
		[SerializeField] private Image slotIcon;

		[SerializeField] private Slider cooldownFill;

		[SerializeField] private SpellInfo spellInfo;

		public SpellInfo SpellInfo
		{
			get => spellInfo;
			set
			{
				spellInfo = value;
				slotIcon.sprite = spellInfo == null ? null : spellInfo.spellIcon;
			}
		}
		
		private float cooldownRemaining;

		private void OnEnable()
		{
			cooldownFill.value = 0;
			if (spellInfo != null) slotIcon.sprite = spellInfo.spellIcon;
		}

		public void UseSpell()
		{
			if (SpellInfo == null || SpellsMenu.I.gameObject.activeSelf || cooldownRemaining > 0 || PlayerMana.I.Mana < spellInfo.mana ||  (spellInfo.name == "Water Shield" && PlayerMovement.I.transform.childCount >= 1) || (spellInfo.name == "House Water Shield" && PlayerHouse.I.transform.GetComponentInChildren<ShieldSpell>() != null)) return;
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

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!SpellsMenu.I.gameObject.activeSelf || cooldownRemaining > 0) return;
			
			if (SelectedSpell.I.Selected == null)
			{
				SelectedSpell.I.Selected = SpellInfo;
				SpellInfo = null;
			}
			else if (SelectedSpell.I.Selected != null)
			{
				(SpellInfo, SelectedSpell.I.Selected) = (SelectedSpell.I.Selected, SpellInfo);
			}
		}
	}
}