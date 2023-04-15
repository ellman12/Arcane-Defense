using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CBC = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace InputSystem
{
	public class SpellSlots : Singleton<SpellSlots>
	{
		[SerializeField] private RectTransform uiElement;
		[SerializeField] private int slotsWidth, widthDelta, slotsHeight;

		private const int NUM_SLOTS = 8;
		[SerializeField] private GameObject selectedIcon;
		private int selectedSlot, activeSlots;
		public int SelectedSlot
		{
			get => selectedSlot;
			set
			{
				if (value < 1) selectedSlot = activeSlots;
				else if (value > activeSlots) selectedSlot = 1;
				else selectedSlot = value;

				selectedIcon.transform.position = spellSlots[selectedSlot].Item2.transform.position;
			}
		}
		
		///Tuple stores the round number that slot is unlocked.
		private readonly Dictionary<int, ValueTuple<int, SpellSlot>> spellSlots = new(NUM_SLOTS);

		private IEnumerator Start()
		{
			InputManager.I.PlayerInput.Spells.Slot1.performed += _ => UseSlot(1);
			InputManager.I.PlayerInput.Spells.Slot2.performed += _ => UseSlot(2);
			InputManager.I.PlayerInput.Spells.Slot3.performed += _ => UseSlot(3);
			InputManager.I.PlayerInput.Spells.Slot4.performed += _ => UseSlot(4);
			InputManager.I.PlayerInput.Spells.Slot5.performed += _ => UseSlot(5);
			InputManager.I.PlayerInput.Spells.Slot6.performed += _ => UseSlot(6);
			InputManager.I.PlayerInput.Spells.Slot7.performed += _ => UseSlot(7);
			InputManager.I.PlayerInput.Spells.Slot8.performed += _ => UseSlot(8);

			InputManager.I.PlayerInput.Spells.SlotDecrease.started += _ => SelectedSlot--;
			InputManager.I.PlayerInput.Spells.SlotIncrease.started += _ => SelectedSlot++;
			InputManager.I.PlayerInput.Spells.UseSelected.started += _ => UseSlot(SelectedSlot);
			
			GameManager.I.RoundAdvance += ExpandSlots;

			for (int i = 1; i <= NUM_SLOTS; i++)
			{
				GameObject slot = GameObject.Find($"Slot {i}");
				spellSlots.Add(i, (i, slot.GetComponent<SpellSlot>()));
				slot.SetActive(false);
			}
			
			spellSlots[1].Item2.gameObject.SetActive(true);
			activeSlots = 1;

			uiElement.sizeDelta = new Vector2(slotsWidth, slotsHeight);

			yield return null;
			SelectedSlot = 1;
		}

		private void UseSlot(int slotNum)
		{
			if (spellSlots[slotNum].Item1 <= GameManager.I.RoundNumber)
				spellSlots[slotNum].Item2.UseSpell();
		}

		private void ExpandSlots(object sender, EventArgs eventArgs)
		{
			foreach (KeyValuePair<int, (int, SpellSlot)> slot in spellSlots)
			{
				if (!slot.Value.Item2.gameObject.activeSelf && slot.Value.Item1 <= GameManager.I.RoundNumber)
				{
					slot.Value.Item2.gameObject.SetActive(true);
					slotsWidth += widthDelta;
					activeSlots++;
				}
			}
			
			uiElement.sizeDelta = new Vector2(slotsWidth, slotsHeight);
		}
	}
}