using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Script.Level
{
    public class ShieldSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> shieldPrefabs;
        public void RespawnShield()
        {
            Clean();
            GenerateShield();
        }
        private void Clean()
        {
            if (transform.childCount == 0) return;
            for (int i = transform.childCount; i == 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        private void GenerateShield()
        {
            int randID = Random.Range(0, shieldPrefabs.Count);
            GameObject shieldToSpawn = shieldPrefabs[randID];
            var shield = Instantiate(shieldToSpawn, transform.position, Quaternion.identity, transform).GetComponent<ShieldManager>();
            shield.Init();
        }
    }
}