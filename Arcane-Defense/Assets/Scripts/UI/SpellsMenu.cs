using System;
using System.Collections.Generic;
using System.Linq;
using InputSystem;
using Spells;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
	public class SpellsMenu : Singleton<SpellsMenu>
	{
		public List<SpellsMenuSlot> spellSlots;
		
		[SerializeField] private List<SpellInfo> unlockableSpells;

		[SerializeField] private List<int> spellRoundUnlock;

		private readonly List<SpellInfo> availableSpells = new();

		private new void Awake()
		{
			base.Awake();
			gameObject.SetActive(false);
			InputManager.I.PlayerInput.SpellsMenu.Toggle.performed += Toggle;

			GameManager.I.RoundAdvance += CheckForUnlockedSpells;

			if (unlockableSpells.Count != spellRoundUnlock.Count) throw new ArgumentOutOfRangeException();
		}

		private void Toggle(InputAction.CallbackContext callbackContext)
		{
			gameObject.SetActive(!gameObject.activeSelf);
			Time.timeScale = gameObject.activeSelf ? 0 : 1;
		}

		private void CheckForUnlockedSpells(object sender, EventArgs eventArgs)
		{
			for (int i = 0; i < unlockableSpells.ToArray().Length; i++)
			{
				if (spellRoundUnlock[i] <= GameManager.I.RoundNumber && spellSlots.Count(s => s.spellInfo != null && s.spellInfo.name == unlockableSpells[i].name) == 0)
				{
					availableSpells.Add(unlockableSpells.First());
					unlockableSpells.RemoveAt(0);
					spellRoundUnlock.RemoveAt(0);
				}
			}
		}
	}
}