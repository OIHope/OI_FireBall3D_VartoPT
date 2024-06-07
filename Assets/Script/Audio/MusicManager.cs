using Assets.Script.compAction;
using UnityEngine;

namespace Assets.Script.Audio
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;

        [SerializeField] private AudioClip menuClip;
        [SerializeField] private AudioClip gameplayClip;

        private bool _menu;
        private bool _gameplay;


        private void PlayMenuMusic()
        {
            musicSource.Stop();
            musicSource.clip = menuClip;
            musicSource.Play();
        }
        private void PlayGameplayMusic()
        {
            musicSource.Stop();
            musicSource.clip = gameplayClip;
            musicSource.Play();
        }
        private void OnEnable()
        {
            PlayMenuMusic();
            // play menu music
            SystemActions.OnPlayerDie += PlayMenuMusic;
            SystemActions.OnLevelComplete += PlayMenuMusic;
            SystemActions.OnGetToMenuButtonClicked += PlayMenuMusic;

            // play gameplay music
            SystemActions.OnStartNewGame += PlayGameplayMusic;

        }
    }
}