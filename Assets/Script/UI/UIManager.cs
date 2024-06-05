using Assets.Script.compAction;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI Screens")]
        [SerializeField] private GameObject uiMainMenu;
        [SerializeField] private GameObject uiPauseMenu;
        [SerializeField] private GameObject uiGameplay;
        [SerializeField] private GameObject uiScoreMenu;
        [SerializeField] private GameObject uiGameOverMenu;
        [SerializeField] private GameObject uiCountdown;

        private void UIDeactivateAll()
        {
            uiMainMenu.SetActive(false);
            uiPauseMenu.SetActive(false);
            uiGameplay.SetActive(false);
            uiScoreMenu.SetActive(false);
            uiGameOverMenu.SetActive(false);
            uiCountdown.SetActive(false);
        }
        public void GetUIMainMenu()
        {
            UIDeactivateAll();
            uiMainMenu.SetActive(true);
        }
        public void GetUIPauseMenu()
        {
            UIDeactivateAll();
            uiPauseMenu.SetActive(true);
        }
        public void GetUIGamaplay()
        {
            UIDeactivateAll();
            uiGameplay.SetActive(true);
        }
        public void GetUIScoreMenu()
        {
            UIDeactivateAll();
            uiScoreMenu.SetActive(true);
        }
        public void GetUIGameOver()
        {
            UIDeactivateAll();
            uiGameOverMenu.SetActive(true);
        }
        public void GetUICountdown()
        {
            UIDeactivateAll();
            uiCountdown.SetActive(true);
        }

        private void OnEnable()
        {
            GetUIMainMenu();
            SystemActions.OnStartNewGame += GetUICountdown;
            SystemActions.OnPlayerDie += GetUIGameOver;
            SystemActions.OnGetToMenuButtonClicked += GetUIMainMenu;
            SystemActions.OnContinueButtonClicked += GetUIGamaplay;
            SystemActions.OnPauseButtonClicked += GetUIPauseMenu;
            SystemActions.OnLevelComplete += GetUIScoreMenu;
        }
    }
}