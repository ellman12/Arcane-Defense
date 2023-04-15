using UnityEngine;

namespace Audio
{
	public class AudioManager : Singleton<AudioManager>
	{
		[SerializeField] private AudioSource audioSource;
		[SerializeField, Range(0, 1)] private float masterVolume;

		public void PlaySound(Audio a)
		{
			// float volumeLevel = masterVolume + a.volumeOffset;
			// aSource.PlayOneShot(a.aClip, Mathf.Clamp(volumeLevel, 0, masterVolume));
			
			audioSource.PlayOneShot(a.audioClip, masterVolume);
		}
	}
}