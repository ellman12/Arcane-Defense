using UnityEngine;

[ExecuteInEditMode]
public class SquareGizmo : MonoBehaviour
{
	[SerializeField] private Color color;
	[SerializeField] private BoxCollider2D boxCollider;

	private void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawWireCube(transform.position, boxCollider.size);
	}
}