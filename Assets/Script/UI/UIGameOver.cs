using Assets.Script.Audio;
using Assets.Script.compAction;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UIGameOver : MonoBehaviour
    {
        [SerializeField] private Button buttonRestart;
        [SerializeField] private Button buttonMenu;

        [SerializeField] private AudioClip clickSound;
        [SerializeField] private AudioClip loseSound;
        private void StartNewGame()
        {
            SystemActions.OnStartNewGame?.Invoke();
            SoundFXManager.instance.PlaySoundFX(clickSound, transform, 0.2f, false);
        }
        private void GetMainMenu()
        {
            SystemActions.OnGetToMenuButtonClicked?.Invoke();
            SoundFXManager.instance.PlaySoundFX(clickSound, transform, 0.2f, false);
        }
        private void OnEnable()
        {
            SoundFXManager.instance.PlaySoundFX(loseSound, transform, 1f, false);

            buttonRestart.onClick.AddListener(StartNewGame);
            buttonMenu.onClick.AddListener(GetMainMenu);
        }
        private void OnDisable()
        {
            buttonRestart.onClick.RemoveAllListeners();
            buttonMenu.onClick.RemoveAllListeners();
        }
    }
}