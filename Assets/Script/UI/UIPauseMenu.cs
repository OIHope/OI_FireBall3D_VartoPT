using Assets.Script.Audio;
using Assets.Script.compAction;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UIPauseMenu : MonoBehaviour
    {
        [SerializeField] private Button buttonContinue;
        [SerializeField] private Button buttonRestart;
        [SerializeField] private Button buttonMenu;

        [SerializeField] private AudioClip clickSound;

        private void ContinueGame()
        {
            gameObject.SetActive(false);
            SystemActions.OnContinueButtonClicked?.Invoke();
            SoundFXManager.instance.PlaySoundFX(clickSound, transform, 0.2f, false);
        }
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
            Time.timeScale = 0f;
            buttonContinue.onClick.AddListener(ContinueGame);
            buttonRestart.onClick.AddListener(StartNewGame);
            buttonMenu.onClick.AddListener(GetMainMenu);
        }
        private void OnDisable()
        {
            Time.timeScale = 1f;
            buttonContinue?.onClick.RemoveAllListeners();
            buttonRestart.onClick.RemoveAllListeners();
            buttonMenu.onClick.RemoveAllListeners();
        }
    }
}