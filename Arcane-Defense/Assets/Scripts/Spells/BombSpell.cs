using System.Collections;
using InputSystem;
using UnityEngine;

namespace Spells
{
	public class BombSpell : Spell
	{
		[SerializeField] private float fuseTime;
		[SerializeField] private Vector2 explosionSize;
		[SerializeField] private new BoxCollider2D collider;

		private void Start()
		{
			transform.position = InputManager.I.CursorPos;
			StartCoroutine(Fuse());
		}

		private IEnumerator Fuse()
		{
			yield return new WaitForSeconds(fuseTime);
			collider.enabled = true;
			collider.size = explosionSize;
			yield return null;
			yield return null;
			Destroy(gameObject);
		}
	}
}