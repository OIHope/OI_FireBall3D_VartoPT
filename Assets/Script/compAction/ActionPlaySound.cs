using Assets.Script.Audio;
using UnityEngine;

namespace Assets.Script.compAction
{
    public class ActionPlaySound : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;
        [SerializeField][Range(0f,1f)] private float volume = 1f;
        [SerializeField] private bool playOnEnable = false;
        [SerializeField] private bool deTune = true;

        public void PlayAudio()
        {
            SoundFXManager.instance.PlaySoundFX(audioClip, transform, volume, deTune);
        }
        private void OnEnable()
        {
            if (playOnEnable)
            {
                SoundFXManager.instance.PlaySoundFX(audioClip, transform, volume, deTune);
            }
        }
    }
}