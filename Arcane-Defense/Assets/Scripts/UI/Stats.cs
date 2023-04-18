using TMPro;
using UnityEngine;
using Utilities;

namespace UI
{
	public class Stats : Singleton<Stats>
	{
		[ReadOnly] public int swordEnemyKills, mageEnemyKills, houseEnemyKills, shrekKills;
		[SerializeField] private TextMeshProUGUI text;

		private void Start() => text.text = "";

		public void UpdateStats() => text.text = $"Kills\nSword - {swordEnemyKills}\nMage - {mageEnemyKills}\nHouse - {houseEnemyKills}\nBoss - {shrekKills}";
	}
}