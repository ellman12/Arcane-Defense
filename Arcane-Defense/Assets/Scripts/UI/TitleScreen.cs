using InputSystem;
using UnityEngine.SceneManagement;
using CBC = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace UI
{
	public class TitleScreen : Singleton<TitleScreen>
	{
		private new void Awake()
		{
			base.Awake();
			InputManager.I.PlayerInput.TitleScreen.StartGame.performed += LoadGame;
		}

		private void LoadGame(CBC _)
		{
			Destroy(InputManager.I);
			Destroy(gameObject);
			SceneManager.LoadScene("Level");
		}
	}
}