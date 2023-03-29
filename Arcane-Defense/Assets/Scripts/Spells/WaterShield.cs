using InputSystem;

namespace Spells
{
	public class WaterShield : Spell
	{
		private void Start()
		{
			transform.position = PlayerMovement.I.transform.position;
			transform.parent = PlayerMovement.I.transform;
		}
	}
}