using Assets.Script.Player;
using UnityEngine;

namespace Assets.Script.Level
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private PlayerController playerController;

        public void RespawnPlayer()
        {
            player.SetActive(false);
            player.SetActive(true);
        }
        public void ActivatePlayerControls()
        {
            playerController.EnablePlayerControl();
        }
        public void DeactivatePlayerControls()
        {
            playerController.DisablePlayerControl();
        }
        public void DespawnPlayer()
        {
            player.SetActive(false);
        }
    }
}