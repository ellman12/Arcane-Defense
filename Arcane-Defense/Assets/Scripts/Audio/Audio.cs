using UnityEngine;

namespace Audio
{
	[CreateAssetMenu(fileName = "Audio", menuName = "Audio", order = 0)]
	public class Audio : ScriptableObject
	{
		public AudioClip audioClip;
		public float volumeOffset;
	}
}