using Player;

namespace PowerUps
{
	public class RepairHouse : PowerUp
	{
		private void OnDestroy() => PlayerHouse.I.RestoreHealth();
	}
}