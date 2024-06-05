using Assets.Script.Game;
using UnityEngine;

public class StartGameAfterCountdown : MonoBehaviour
{
    [SerializeField] private GameplayController gameplayController;
    [SerializeField] private GameManager gameManager;
    public void StartGame()
    {
        gameplayController.StartGame();
        gameManager.StartTimer();
    }
}
