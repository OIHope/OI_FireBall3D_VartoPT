using Assets.Script.Audio;
using Assets.Script.compAction;
using Assets.Script.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UIGameScore : MonoBehaviour
    {
        [SerializeField] private Button buttonNextLevel;
        [Space]
        [SerializeField] private GameObject[] scoreImageStars;
        [SerializeField] private TextMeshProUGUI textTimeSpent;
        [SerializeField] private TextMeshProUGUI textLevelStats;
        [Space]
        [SerializeField] private GameManager gameManager;

        [SerializeField] private AudioClip clickSound;
        [SerializeField] private AudioClip victorySound;

        private void ShowStats()
        {
            foreach (var star in scoreImageStars) { star.SetActive(false); }

            int timeSpent = gameManager.GetTimeSpent;

            int oneStarTime = (int)gameManager.GetTimeStarsInfo.x;
            int twoStarsTime = (int)gameManager.GetTimeStarsInfo.y;
            int threeStarsTime = (int)gameManager.GetTimeStarsInfo.z;

            textTimeSpent.text = ($"Time spent: {timeSpent}s");
            textLevelStats.text = ($"Time for 1 star: {oneStarTime}s\n" +
                $"Time for 2 stars: {twoStarsTime}s\n" +
                $"Time for 3 stars: {threeStarsTime}s");

            if (timeSpent <= oneStarTime) scoreImageStars[0].SetActive(true);
            if (timeSpent <= twoStarsTime) scoreImageStars[1].SetActive(true);
            if (timeSpent <= threeStarsTime) scoreImageStars[2].SetActive(true);

            SoundFXManager.instance.PlaySoundFX(victorySound, transform, 1f, false);
        }
        private void NextLevel()
        {
            SystemActions.OnStartNewGame?.Invoke();
            SoundFXManager.instance.PlaySoundFX(clickSound, transform, 0.2f, false);
        }
        private void OnEnable()
        {
            ShowStats();
            buttonNextLevel.onClick.AddListener(NextLevel);
        }
        private void OnDisable()
        {
            buttonNextLevel.onClick.RemoveAllListeners();
        }
    }
}