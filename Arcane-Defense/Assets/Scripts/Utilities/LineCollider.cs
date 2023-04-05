using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Utilities
{
	//God bless this man: https://youtu.be/qILF--NMwxM
	[RequireComponent(typeof(EdgeCollider2D), typeof(LineRenderer))]
	public class LineCollider : MonoBehaviour
	{
		private EdgeCollider2D edgeCollider;
		private LineRenderer lineRenderer;

		private void Start()
		{
			edgeCollider = GetComponent<EdgeCollider2D>();
			lineRenderer = GetComponent<LineRenderer>();
		}

		//LateUpdate is needed so it renders after the line renders.
		private void LateUpdate() => SetEdgeCollider();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetEdgeCollider()
		{
			List<Vector2> edges = new();

			for (int point = 0; point < lineRenderer.positionCount; point++)
			{
				Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
				edges.Add(new Vector2(lineRendererPoint.x - transform.position.x, lineRendererPoint.y - transform.position.y)); //The math with this is wack man. I had to use subtraction when they're spawned in from a slot, but during the initial testing when I just had it in the scene, I had to use + instead of -.
			}

			edgeCollider.SetPoints(edges);
		}
	}
}