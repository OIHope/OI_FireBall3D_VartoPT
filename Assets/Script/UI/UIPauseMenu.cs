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

        private void ContinueGame()
        {
            gameObject.SetActive(false);
            SystemActions.OnContinueButtonClicked?.Invoke();
        }
        private void StartNewGame()
        {
            SystemActions.OnStartNewGame?.Invoke();
        }
        private void GetMainMenu()
        {
            SystemActions.OnGetToMenuButtonClicked?.Invoke();
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