using System;

namespace InputSystem
{
	public class InputManager : Singleton<InputManager>
	{
		public PlayerInput PlayerInput { get; private set; }
		
		private new void Awake()
		{
			PlayerInput = new PlayerInput();
			PlayerInput.Enable();
			base.Awake();
		}
	}
}