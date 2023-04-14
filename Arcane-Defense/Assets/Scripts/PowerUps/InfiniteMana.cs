using Player;

namespace PowerUps
{
	public class InfiniteMana : PowerUp
	{
		private void Update()
		{
			if (!active) return;
			PlayerMana.I.Mana = PlayerMana.I.MaxMana;
		}
	}
}