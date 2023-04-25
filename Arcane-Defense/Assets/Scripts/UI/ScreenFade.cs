using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(Image))]
	public class ScreenFade : Singleton<ScreenFade>
	{
		[SerializeField] private Image image;

		[SerializeField] private float speed;

		public void FadeOut()
		{
			StartCoroutine(FadeOutCo());
		}

		private IEnumerator FadeOutCo()
		{
			for (float f = 0; f <= 1; f += speed * Time.deltaTime)
			{
				image.color = Color.Lerp(Color.black, Color.clear, f);
				yield return null;
			}
			image.color = Color.clear;
		}
	}
}