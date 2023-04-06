using UnityEngine;

namespace Spells
{
	public class LinearTravelSpell : Spell
	{
		[SerializeField] public float speed;

		private void Start() //Thanks Unity Forums, very cool.
		{
			if (target == null)
			{
				targetPos = Input.mousePosition;
				startPos = MainCamera.I.camera!.WorldToScreenPoint(transform.position);
			}
			else
			{
				targetPos = target.position;
				startPos = transform.position;
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
	}
}