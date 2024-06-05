using Assets.Script.compAction;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private Button buttonStart;

        private void StartNewGame()
        {
            SystemActions.OnStartNewGame?.Invoke();
        }
        private void OnEnable()
        {
            buttonStart.onClick.AddListener(StartNewGame);
        }
        private void OnDisable()
        {
            buttonStart.onClick.RemoveAllListeners();
        }
    }
}