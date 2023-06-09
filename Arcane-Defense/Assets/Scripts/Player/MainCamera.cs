using InputSystem;
using UnityEngine;

namespace Player
{
	public class MainCamera : Singleton<MainCamera>
	{
		[SerializeField] private float distance, smoothTime = 0.3f;
		[SerializeField] private Vector2 minBounds;
		[SerializeField] private Vector2 maxBounds;

		[HideInInspector] public new Camera camera;

		private Transform target;
		private Vector3 _;

		private void Start()
		{
			camera = Camera.main;
			target = PlayerMovement.I.transform;
		}

		private void LateUpdate()
		{
			if (target == null) return;
			
			Vector3 targetPosition = new Vector3(
				Mathf.Clamp(target.position.x, minBounds.x, maxBounds.x),
				Mathf.Clamp(target.position.y, minBounds.y, maxBounds.y),
				distance);

			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _, smoothTime);
		}
	}
}