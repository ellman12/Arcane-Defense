using System.Collections;
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
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = -MainCamera.I.camera.transform.position.z;
			Vector3 worldPosition = MainCamera.I.camera.ScreenToWorldPoint(mousePosition);
			transform.position = worldPosition;

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