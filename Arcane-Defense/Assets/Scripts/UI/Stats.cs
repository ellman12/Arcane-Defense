using TMPro;
using UnityEngine;
using Utilities;

namespace UI
{
	public class Stats : Singleton<Stats>
	{
		[ReadOnly] public int swordEnemyKills, mageEnemyKills, houseEnemyKills, shrekKills, shadowShrekKills;
		[SerializeField] private TextMeshProUGUI text;

		private void Start() => text.text = "";

		public void UpdateStats()
		{
			text.text = "Kills\n";

			if (swordEnemyKills > 0)
				text.text += $"Sword: {swordEnemyKills}\n";
			if (mageEnemyKills > 0)
				text.text += $"Mage: {mageEnemyKills}\n";
			if (houseEnemyKills > 0)
				text.text += $"House: {houseEnemyKills}\n";
			if (shrekKills > 0)
				text.text += $"Shrek: {shrekKills}\n";
			if (shadowShrekKills > 0)
				text.text += $"Shadow: {shadowShrekKills}\n";
		}
	}
}