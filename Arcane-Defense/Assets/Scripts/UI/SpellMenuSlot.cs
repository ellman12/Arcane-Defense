using System;
using Spells;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
	public class SpellMenuSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
	{
		[HideInInspector] public SpellInfo spellInfo;

		private void Start()
		{
			SpellNameText.I.text.text = SpellInfoText.I.text.text = "";
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			throw new NotImplementedException();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (spellInfo == null) return;

			SpellNameText.I.text.text = spellInfo.name;
			SpellInfoText.I.text.text = spellInfo.info;
		}
	}
}