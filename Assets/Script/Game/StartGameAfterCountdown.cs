using UnityEngine;

public class StartGameAfterCountdown : MonoBehaviour
{
    [SerializeField] private PauseManager pauseManager;

    public void StartGame()
    {
        pauseManager.SetPauseGame(false);
    }
}
