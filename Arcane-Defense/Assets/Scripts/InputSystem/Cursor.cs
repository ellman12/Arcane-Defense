using UnityEngine;
using CBC = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace InputSystem
{
	public class Cursor : Singleton<Cursor>
	{
		[SerializeField] private float cursorDistance;
		
		[HideInInspector] public Vector3 rightStickInput;

		private void Start()
		{
			if (InputManager.I.gamepadActive)
			{
				InputManager.I.PlayerInput.Cursor.Cursor.performed += OnInput;
				InputManager.I.PlayerInput.Cursor.Cursor.canceled += OnInput;
				void OnInput(CBC context) => rightStickInput = context.ReadValue<Vector2>();
			}
			else
				Destroy(gameObject);
		}
		
		private void Update() => transform.position = PlayerMovement.I.transform.position + rightStickInput * cursorDistance;
	}
}