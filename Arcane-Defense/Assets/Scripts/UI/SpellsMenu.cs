using System.Collections.Generic;
using InputSystem;

namespace UI
{
	public class SpellsMenu : Singleton<SpellsMenu>
	{
		public List<SpellsMenuSlot> spellSlots;

		private new void Awake()
		{
			base.Awake();
			gameObject.SetActive(false);
			InputManager.I.PlayerInput.SpellsMenu.Toggle.performed += _ => gameObject.SetActive(!gameObject.activeSelf);
		}
	}
}