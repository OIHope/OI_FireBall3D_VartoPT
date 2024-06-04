using Assets.Script.Level;
using UnityEngine;

namespace Assets.Script.Game
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner playerSpawner;
        [SerializeField] private TowerSpawner towerSpawner;
        [SerializeField] private ShieldSpawner shieldSpawner;
        [Space]
        [SerializeField] private PauseManager pausedManager;

        public void StartNewGame()
        {
            playerSpawner.ActivatePlayer();
            towerSpawner.RespawnTower();
            shieldSpawner.RespawnShield();

            pausedManager.SetPauseGame(true);
        }
    }
}