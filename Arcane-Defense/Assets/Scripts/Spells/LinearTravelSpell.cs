using UnityEngine;

namespace Spells
{
	public class LinearTravelSpell : Spell
	{
		[SerializeField] private float speed;

		private void Awake() //Thanks Unity Forums, very cool.
		{
			Vector3 mousePos = Input.mousePosition;
			Vector3 spellPos = Camera.main!.WorldToScreenPoint(transform.position);
			mousePos.x -= spellPos.x;
			mousePos.y -= spellPos.y;
			float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
			
			Destroy(gameObject, 20);
		}

		private void Update()
		{
			transform.position += transform.right * (speed * Time.deltaTime);
		}
	}
}