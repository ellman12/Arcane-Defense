using System;
using Spells;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
	public class SpellsMenuSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
	{
		[SerializeField] private Image slotIcon;
		
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
		
		private void Start()
		{
			if (spellInfo != null)
				SpellInfo = SpellInfo;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
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

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (spellInfo == null) return;

			SpellNameText.I.text.text = spellInfo.name;
			SpellInfoText.I.text.text = spellInfo.info;
		}
	}
}