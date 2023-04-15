using UnityEngine;

namespace Audio
{
	[CreateAssetMenu(fileName = "Audio", menuName = "Audio", order = 0)]
	public class Audio : ScriptableObject
	{
		public AudioClip audioClip;
		[Range(0, 1)] public float volumeOffset;
	}
}