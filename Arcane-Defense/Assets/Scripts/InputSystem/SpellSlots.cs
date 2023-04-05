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

		private const int NUM_SLOTS = 7;
		private readonly Dictionary<int, ValueTuple<int, SpellSlot>> spellSlots = new(NUM_SLOTS);

		private void Start()
		{
			InputManager.I.PlayerInput.Spells.Slot1.performed += _ => UseSlot(1);
			InputManager.I.PlayerInput.Spells.Slot2.performed += _ => UseSlot(2);
			InputManager.I.PlayerInput.Spells.Slot3.performed += _ => UseSlot(3);
			InputManager.I.PlayerInput.Spells.Slot4.performed += _ => UseSlot(4);
			InputManager.I.PlayerInput.Spells.Slot5.performed += _ => UseSlot(5);
			InputManager.I.PlayerInput.Spells.Slot6.performed += _ => UseSlot(6);
			InputManager.I.PlayerInput.Spells.Slot7.performed += _ => UseSlot(7);
			
			GameManager.I.RoundAdvance += ExpandSlots;

			for (int i = 1; i <= NUM_SLOTS; i++)
			{
				GameObject slot = GameObject.Find($"Slot {i}");
				spellSlots.Add(i, (i, slot.GetComponent<SpellSlot>()));
				// slot.SetActive(i == 1);
			}

			uiElement.sizeDelta = new Vector2(slotsWidth, slotsHeight);
		}

		private void UseSlot(int slotNum)
		{
			// if (spellSlots[slotNum].Item1 <= GameManager.I.RoundNumber)
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