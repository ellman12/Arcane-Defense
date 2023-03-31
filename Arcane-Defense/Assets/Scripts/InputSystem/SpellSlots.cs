using System.Collections.Generic;
using Spells;
using UnityEngine;
using CBC = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace InputSystem
{
	public class SpellSlots : Singleton<SpellSlots>
	{
		[SerializeField] private List<Spell> slots;
		
		private new void Awake()
		{
			base.Awake();
			InputManager.I.PlayerInput.Spells.Slot1.performed += Slot1Use;
			InputManager.I.PlayerInput.Spells.Slot2.performed += Slot2Use;
			InputManager.I.PlayerInput.Spells.Slot3.performed += Slot3Use;
			InputManager.I.PlayerInput.Spells.Slot4.performed += Slot4Use;
			InputManager.I.PlayerInput.Spells.Slot5.performed += Slot5Use;
			InputManager.I.PlayerInput.Spells.Slot6.performed += Slot6Use;
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
			Instantiate(slots[slotNum - 1], transform.position, Quaternion.identity);
		}
	}
}