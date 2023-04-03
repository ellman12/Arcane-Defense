using InputSystem;
using UnityEngine;

namespace Spells
{
	public class LinearTravelSpell : Spell
	{
		[SerializeField] private float speed;
		[HideInInspector] public Transform start, target;

		private void Start() //Thanks Unity Forums, very cool.
		{
			Vector3 targetPos = target == null ? Input.mousePosition : target.position;
			Vector3 spellPos = Camera.main!.WorldToScreenPoint(transform.position);
			targetPos.x -= spellPos.x;
			targetPos.y -= spellPos.y;
			float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
			transform.position = start == null ? PlayerMovement.I.transform.position : start.position;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
			Destroy(gameObject, 20);
		}

		private void Update()
		{
			transform.position += transform.right * (speed * Time.deltaTime);
		}
	}
}