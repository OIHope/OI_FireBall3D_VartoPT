using Assets.Script.Audio;
using Assets.Script.compAction;
using Assets.Script.Game;
using Assets.Script.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UIGameplay : MonoBehaviour
    {
        [SerializeField] private Button buttonPause;

        [SerializeField] private TextMeshProUGUI textTimeLeft;
        [SerializeField] private GameManager gameManager;

        [SerializeField] private AudioClip clickSound;

        private void Update()
        {
            textTimeLeft.text = ("Time left: " + gameManager.GetLevelTime.ToString());
        }
        private void PauseGame()
        {
            SystemActions.OnPauseButtonClicked?.Invoke();
            SoundFXManager.instance.PlaySoundFX(clickSound, transform, 0.2f, false);
        }
        private void OnEnable()
        {
            buttonPause.onClick.AddListener(PauseGame);
        }
        private void OnDisable()
        {
            buttonPause.onClick.RemoveAllListeners();
        }
    }
}