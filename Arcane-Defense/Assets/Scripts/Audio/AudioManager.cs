using UnityEngine;

namespace Audio
{
	public class AudioManager : Singleton<AudioManager>
	{
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private float masterVolume;

		public void PlayAudio(Audio a)
		{
			audioSource.PlayOneShot(a.audioClip, masterVolume + a.volumeOffset);
		}
	}
}