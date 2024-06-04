using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Level
{
    public class TowerSpawner : MonoBehaviour
    {
        [SerializeField] private Vector2Int spawnCountRange;
        [SerializeField] private List<GameObject> blockPrefabs;
        [SerializeField] private List<GameObject> treasurePrefabs;
        [SerializeField] private float spaceBetweenTargets = 2f;
        [SerializeField] private float blockHight = 1f;

        private Vector3 _lastSpawnedPos;
        public float NewSpawnPosModifier => blockHight + spaceBetweenTargets;

        private void Awake()
        {
            RespawnTower();
        }
        private void RespawnTower()
        {
            SpawnBlocks(blockPrefabs, Random.Range(spawnCountRange.x, spawnCountRange.y), false, transform.position);
            SpawnBlocks(treasurePrefabs, 1, true, _lastSpawnedPos);
        }
        private void SpawnBlocks(List<GameObject> list, int count, bool random, Vector3 startPos)
        {
            int spawnCount = count;
            int currID = list.Count-1;
            Vector3 lastSpawnedPos = startPos;

            for (int i = 0; i < spawnCount; i++)
            {
                currID = !random ? GetID(currID, list.Count) : Random.Range(0, list.Count);
                Target target = Instantiate(list[currID], lastSpawnedPos, Quaternion.identity, transform).GetComponent<Target>();
                target.Init();
                target.OnDestroyAction += MoveBlocksDowm;
                lastSpawnedPos = new Vector3(lastSpawnedPos.x, lastSpawnedPos.y + NewSpawnPosModifier, lastSpawnedPos.z);
            }
            _lastSpawnedPos = lastSpawnedPos;
        }
        private int GetID(int currentID, int maxRangeID)
        {
            currentID++;
            return (currentID >= maxRangeID) ? 0 : currentID;
        }
        private void MoveBlocksDowm()
        {
            foreach (Transform block in transform)
            {
                block.GetComponent<Target>().MoveBlockDown(NewSpawnPosModifier);
            }
        }
    }
}