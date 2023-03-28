using System;
using UnityEngine;
using CBC = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace InputSystem
{
	public class PlayerMovement : Singleton<PlayerMovement>
	{
		[NonSerialized] public Vector3 movementInput;
		
		[SerializeField] private float moveSpeed;

		private void Start()
		{
			InputManager.I.PlayerInput.Movement.Movement.performed += OnMove;
			InputManager.I.PlayerInput.Movement.Movement.canceled += OnMove;

			void OnMove(CBC context) => movementInput = context.ReadValue<Vector2>();
		}

		private void Update()
		{
			transform.position += (Vector3)movementInput * (moveSpeed * Time.deltaTime);
		}
	}
}