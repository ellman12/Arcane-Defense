using System.Collections;
using InputSystem;
using UnityEngine;

namespace Spells
{
	public class BombSpell : Spell
	{
		[SerializeField] private float fuseTime, explosionTime;
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
			yield return new WaitForSeconds(explosionTime);
			Destroy(gameObject);
		}
	}
}