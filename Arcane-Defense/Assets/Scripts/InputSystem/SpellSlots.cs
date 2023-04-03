using System;
using System.Collections.Generic;
using UnityEngine;
using CBC = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace InputSystem
{
	public class SpellSlots : Singleton<SpellSlots>
	{
		[SerializeField] private RectTransform uiElement;
		[SerializeField] private int slotsWidth, widthDelta, slotsHeight;

		private readonly Dictionary<int, ValueTuple<int, SpellSlot>> spellSlots = new(6);

		private void Start()
		{
			InputManager.I.PlayerInput.Spells.Slot1.performed += Slot1Use;
			InputManager.I.PlayerInput.Spells.Slot2.performed += Slot2Use;
			InputManager.I.PlayerInput.Spells.Slot3.performed += Slot3Use;
			InputManager.I.PlayerInput.Spells.Slot4.performed += Slot4Use;
			InputManager.I.PlayerInput.Spells.Slot5.performed += Slot5Use;
			InputManager.I.PlayerInput.Spells.Slot6.performed += Slot6Use;
			
			GameManager.I.RoundAdvance += ExpandSlots;

			for (int i = 1; i <= 6; i++)
			{
				GameObject slot = GameObject.Find($"Slot {i}");
				spellSlots.Add(i, (i, slot.GetComponent<SpellSlot>()));
				slot.SetActive(i == 1);
			}

			uiElement.sizeDelta = new Vector2(slotsWidth, slotsHeight);
		}

		//I hate this so much.
		private void Slot1Use(CBC _) => UseSlot(1);
		private void Slot2Use(CBC _) => UseSlot(2);
		private void Slot3Use(CBC _) => UseSlot(3);
		private void Slot4Use(CBC _) => UseSlot(4);
		private void Slot5Use(CBC _) => UseSlot(5);
		private void Slot6Use(CBC _) => UseSlot(6);

		private void UseSlot(int slotNum)
		{
			if (spellSlots[slotNum].Item1 <= GameManager.I.RoundNumber)
				spellSlots[slotNum].Item2.UseSpell();
		}

		private void ExpandSlots(object sender, EventArgs eventArgs)
		{
			foreach (var slot in spellSlots)
			{
				if (!slot.Value.Item2.gameObject.activeSelf && slot.Value.Item1 <= GameManager.I.RoundNumber)
				{
					slot.Value.Item2.gameObject.SetActive(true);
					slotsWidth += widthDelta;
				}
			}
			
			uiElement.sizeDelta = new Vector2(slotsWidth, slotsHeight);
		}
	}
}