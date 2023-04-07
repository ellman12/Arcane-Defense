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
			if (target == null)
			{
				startPos = MainCamera.I.camera!.WorldToScreenPoint(transform.position);
				targetPos = Input.mousePosition;
			}
			else
			{
				startPos = transform.position;
				targetPos = target.position;
			}
			
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
			if (col.CompareTag("Player"))
			{
				Destroy(gameObject);
				PlayerHealth.I.LoseHealth(contactDamage);
			}
			else if (col.TryGetComponent(out LinearTravelSpell other) && enemySpell != other.enemySpell)
			{
				Destroy(gameObject);
				Destroy(other.gameObject);
			}
		}
	}
}