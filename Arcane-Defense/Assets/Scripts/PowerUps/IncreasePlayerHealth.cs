using Player;
using UnityEngine;

namespace PowerUps
{
	public class IncreasePlayerHealth : PowerUp
	{
		[SerializeField] private int healthDelta;
		
		private void OnDestroy() => PlayerHealth.I.Health = PlayerHealth.I.MaxHealth += healthDelta;
	}
}