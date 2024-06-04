using UnityEngine;

namespace Assets.Script.Level
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        public void ActivatePlayer()
        {
            player.SetActive(true);
        }
        public void DeactivatePlayer()
        {
            player.SetActive(false);
        }
    }
}