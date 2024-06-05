using Assets.Script.compAction;
using Assets.Script.Level;
using UnityEngine;

namespace Assets.Script.Game
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner playerSpawner;
        [SerializeField] private TowerSpawner towerSpawner;
        [SerializeField] private ShieldSpawner shieldSpawner;
        [SerializeField] private GameObject bulletParent;

        public void LoadNewGame()
        {
            playerSpawner.RespawnPlayer();
            towerSpawner.RespawnTower();
            shieldSpawner.RespawnShield();
        }
        public void StartGame()
        {
            playerSpawner.ActivatePlayerControls();
        }
        public void HoldGame()
        {
            playerSpawner.DeactivatePlayerControls();
        }
        public void StopGame()
        {
            playerSpawner.DespawnPlayer();
            towerSpawner.DespawnTower();
            shieldSpawner.DespawnShield();
        }
        private void CleanBullets()
        {
            foreach (Transform child in bulletParent.transform)
            {
                Destroy(child.gameObject);
            }
        }
        private void OnEnable()
        {
            SystemActions.OnStartNewGame += LoadNewGame;
            SystemActions.OnPlayerDie += HoldGame;
            SystemActions.OnGetToMenuButtonClicked += StopGame;
            SystemActions.OnPauseButtonClicked += HoldGame;
            SystemActions.OnLevelComplete += HoldGame;
            SystemActions.OnLevelComplete += CleanBullets;
            SystemActions.OnContinueButtonClicked += StartGame;
        }
    }
}