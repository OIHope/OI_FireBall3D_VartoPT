using UnityEngine;

namespace Assets.Script.Game
{
    public class GameManager : MonoBehaviour
    {
        [Header("UI Screens")]
        [SerializeField] private GameObject uiMainMenu;
        [SerializeField] private GameObject uiPauseMenu;
        [SerializeField] private GameObject uiGameplay;
        [SerializeField] private GameObject uiScoreMenu;
        [SerializeField] private GameObject uiGameOverMenu;
        [SerializeField] private GameObject uiCountdown;
        [Space]
        [Header("Gameplay Related")]
        [SerializeField] private GameplayController gpGameScene;

        private void Start()
        {
            GetUIMainMenu();
        }
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
    }
}