using UnityEngine;

namespace Spells
{
	public class LinearTravelSpell : Spell
	{
		[SerializeField] public float speed;
		[HideInInspector] public Transform target;

		private void Start() //Thanks Unity Forums, very cool.
		{
			Vector3 targetPos, spellPos;
			if (target == null)
			{
				targetPos = Input.mousePosition;
				spellPos = MainCamera.I.camera!.WorldToScreenPoint(transform.position);
			}
			else
			{
				targetPos = target.position;
				spellPos = transform.position;
			}
			
			targetPos.x -= spellPos.x;
			targetPos.y -= spellPos.y;
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