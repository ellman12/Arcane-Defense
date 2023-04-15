using Player;
using UnityEngine;

namespace PowerUps
{
	public class IncreaseHouseHealth : PowerUp
	{
		[SerializeField] private int maxHealthDelta;
		
		private void OnDestroy()
		{
			PlayerHouse.I.MaxHealth += maxHealthDelta;
			PlayerHouse.I.Health = PlayerHouse.I.MaxHealth;
		}
	}
}