using UnityEngine;

namespace PowerUps
{
	public abstract class PowerUp : MonoBehaviour
	{
		protected bool active;
		
		[SerializeField] private float duration;

		[SerializeField] private SpriteRenderer spriteRenderer;

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (!active && col.CompareTag("Player"))
			{
				active = true;
				spriteRenderer.enabled = false;
				Destroy(gameObject, duration);
			}
		}
	}
}