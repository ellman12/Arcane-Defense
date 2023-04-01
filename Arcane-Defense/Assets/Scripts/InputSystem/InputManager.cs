using UnityEngine;

namespace InputSystem
{
	public class InputManager : Singleton<InputManager>
	{
		public PlayerInput PlayerInput { get; private set; }
		
		private new void Awake()
		{
			Time.timeScale = 1;
			PlayerInput = new PlayerInput();
			PlayerInput.Enable();
			base.Awake();
		}

		private void OnDestroy()
		{
			PlayerInput.Disable();
			PlayerInput = null;
		}
	}
}