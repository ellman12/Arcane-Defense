using InputSystem;
using Player;
using UnityEngine;

namespace Spells
{
	public class LinearTravelSpell : Spell
	{
		public float speed;

		private void Start() //Thanks Unity Forums, very cool.
		{
			startPos = transform.position;
			targetPos = target == null ? InputManager.I.CursorPos : target.position;

			targetPos.x -= startPos.x;
			targetPos.y -= startPos.y;
			float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
			Destroy(gameObject, 20);
		}

		private void Update()
		{
			transform.position += transform.right * (speed * Time.deltaTime);
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.TryGetComponent(out LinearTravelSpell other))
			{
				if (col.CompareTag("Player") && enemySpell)
				{
					Destroy(gameObject);
					PlayerHealth.I.LoseHealth(contactDamage);
				}
				else if (enemySpell != other.enemySpell)
				{
					Destroy(gameObject);
					Destroy(other.gameObject);
				}
			}
		}
	}
}