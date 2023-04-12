using System.Collections.Generic;
using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
	public class SpellsMenu : Singleton<SpellsMenu>
	{
		public List<SpellsMenuSlot> spellSlots;

		private new void Awake()
		{
			base.Awake();
			gameObject.SetActive(false);
			InputManager.I.PlayerInput.SpellsMenu.Toggle.performed += Toggle;

			void Toggle(InputAction.CallbackContext callbackContext)
			{
				gameObject.SetActive(!gameObject.activeSelf);
				Time.timeScale = gameObject.activeSelf ? 0 : 1;
			}
		}
	}
}