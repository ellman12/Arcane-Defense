using UnityEngine;
using UnityEngine.UI;

namespace Player
{
	public class StatBar : MonoBehaviour
	{
		[SerializeField] private float barWidth;
		[SerializeField] private RectTransform rectTransform;
		[SerializeField] private Slider slider;
		[SerializeField] private Gradient gradient;
		[SerializeField] private Image fill;

		public void SetMaxValue(int maxHealth)
		{
			slider.maxValue = maxHealth;
			slider.value = maxHealth;
			rectTransform.sizeDelta = new Vector2(barWidth, maxHealth);
			fill.color = gradient.Evaluate(1);
		}

		public void SetValue(int health)
		{
			slider.value = health;
			fill.color = gradient.Evaluate(slider.normalizedValue);
		}
	}
}