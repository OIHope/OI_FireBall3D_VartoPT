using UnityEngine;

namespace Assets.Script.Audio
{
    public class SoundFXManager : MonoBehaviour
    {
        public static SoundFXManager instance;
        [SerializeField] private AudioSource audioFXObject;

        private void Awake()
        {
            if (instance == null) { instance = this; }
        }
        public void PlaySoundFX(AudioClip audioClip, Transform spawnTransform, float volume, bool deTune)
        {
            AudioSource audioSource = Instantiate(audioFXObject, spawnTransform.position, Quaternion.identity);
            audioSource.clip = audioClip;
            audioSource.volume = volume;
            audioSource.pitch = deTune ? Random.Range(0.8f, 1.2f) : 1f;
            audioSource.Play();
            Destroy(audioSource, audioSource.clip.length);
        }
    }
}