using UnityEngine;

namespace Audio
{
	public class AudioManager : Singleton<AudioManager>
	{
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private float masterVolume;

		public void PlaySound(Audio a)
		{
			audioSource.PlayOneShot(a.audioClip, masterVolume + a.volumeOffset);
		}
	}
}