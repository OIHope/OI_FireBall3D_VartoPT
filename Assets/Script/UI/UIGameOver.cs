using Assets.Script.compAction;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UIGameOver : MonoBehaviour
    {
        [SerializeField] private Button buttonRestart;
        [SerializeField] private Button buttonMenu;

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