using Spells;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class SelectedSpell : Singleton<SelectedSpell>
	{
		[SerializeField] private Image spellIcon;
		
		private SpellInfo selected;
		public SpellInfo Selected
		{
			get => selected;
			set
			{
				selected = value;
				if (selected == null)
				{
					gameObject.SetActive(false);
					spellIcon.sprite = null;
				}
				else
				{
					gameObject.SetActive(true);
					spellIcon.sprite = selected.spellIcon;
				}
			}
		}

		private void Update()
		{
			if (selected == null) return;
			
			transform.position = Input.mousePosition;
		}
	}
}