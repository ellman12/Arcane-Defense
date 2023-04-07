using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
	public class InputManager : Singleton<InputManager>
	{
		public PlayerInput PlayerInput { get; private set; }

		public bool gamepadActive;

		[SerializeField] private float rightStickDeadZone;

		///The position of the Mouse or, if a controller is present, the Cursor.
		public Vector3 CursorPos
		{
			get
			{
				if (gamepadActive && Cursor.I.rightStickInput.magnitude > rightStickDeadZone)
					return Cursor.I.transform.position;
				
				Vector3 mousePosition = Input.mousePosition;
				mousePosition.z = -MainCamera.I.camera.transform.position.z;
				Vector3 returnVal = MainCamera.I.camera.ScreenToWorldPoint(mousePosition);
				return returnVal;
			}
		}

		private new void Awake()
		{
			Time.timeScale = 1;
			PlayerInput = new PlayerInput();
			PlayerInput.Enable();
			gamepadActive = Gamepad.current != null;
			base.Awake();
		}

		private void OnDestroy()
		{
			PlayerInput.Disable();
			PlayerInput = null;
		}
	}
}