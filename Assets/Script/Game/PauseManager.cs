using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void SetPauseGame(bool pause)
    {
        Time.timeScale = pause ? 0.0f : 1.0f;
    }
}
