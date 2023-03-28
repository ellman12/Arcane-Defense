using UnityEngine;

[ExecuteInEditMode]
public class SquareGizmo : MonoBehaviour
{
	[SerializeField] private Color color = Color.white;
	private BoxCollider2D boxCollider;

	private void Start() => boxCollider = GetComponent<BoxCollider2D>();

	private void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawWireCube(transform.position, boxCollider.size);
	}
}