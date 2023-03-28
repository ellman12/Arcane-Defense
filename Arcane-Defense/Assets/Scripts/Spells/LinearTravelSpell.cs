using UnityEngine;

namespace Spells
{
	public class LinearTravelSpell : MonoBehaviour
	{
		[SerializeField] private float speed;
		private Vector3 worldPOS, direction;

		private void Awake()
		{
			Ray ray = Camera.main!.ScreenPointToRay(Input.mousePosition);
			worldPOS = ray.GetPoint(10);
			worldPOS.z = 0;
			direction = worldPOS.normalized;
		}

		private void Update()
		{
			transform.position += direction * (speed * Time.deltaTime);
		}
	}
}