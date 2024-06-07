using Assets.Script.Audio;
using Assets.Script.compAction;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private Button buttonStart;
        [SerializeField] private AudioClip clickSound;

        private void StartNewGame()
        {
            SystemActions.OnStartNewGame?.Invoke();
            SoundFXManager.instance.PlaySoundFX(clickSound, transform, 0.2f, false);
        }
        private void OnEnable()
        {
            buttonStart.onClick.AddListener(StartNewGame);
        }
        private void OnDisable()
        {
            buttonStart.onClick.RemoveAllListeners();
        }
    }
}