using Player;
using UnityEngine;

namespace PowerUps
{
	public class IncreasePlayerMana : PowerUp
	{
		[SerializeField] private int manaDelta;
		
		private void OnDestroy() => PlayerMana.I.Mana = PlayerMana.I.MaxMana += manaDelta;
	}
}