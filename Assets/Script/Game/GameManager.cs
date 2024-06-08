using Assets.Script.compAction;
using Assets.Script.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Game
{
    public class GameManager : MonoBehaviour
    {
        [Header("Score Related")]
        [SerializeField] private GameObject towerParent;
        [SerializeField] private List<GameObject> towerBlocks;
        [SerializeField] private GameObject shieldBlock;
        [SerializeField] private int timeForLevel;
        private int _initTime;
        private int _timeFor1star;
        private int _timeFor2star;
        private int _timeFor3star;

        private Coroutine levelTimerCoroutine;
        public int GetLevelTime => timeForLevel;
        public int GetTimeSpent => _initTime - timeForLevel;
        public Vector3 GetTimeStarsInfo => new Vector3(_timeFor1star, _timeFor2star, _timeFor3star);
        private void Awake() => Application.targetFrameRate = 60;
        public void StartTimer()
        {
            levelTimerCoroutine = StartCoroutine(LevelTimer());
        }
        private void StopTimer()
        {
            if (levelTimerCoroutine == null) return;
            StopCoroutine(levelTimerCoroutine);
        }
        private IEnumerator LevelTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                timeForLevel--;
                if (timeForLevel <= 0)
                {
                    SystemActions.OnPlayerDie?.Invoke();
                    break;
                }
            }
        }
        private void CalculateLevelTime()
        {
            int time = 0;

            int shieldValue = shieldBlock.GetComponentInChildren<ShieldManager>().GetDifficultyValue;
            int towerBlocksValue = 0;
            towerBlocks.Clear();
            foreach (Transform child in towerParent.transform )
            {
                towerBlocks.Add(child.gameObject);
            }
            foreach (GameObject block in towerBlocks)
            {
                towerBlocksValue += block.GetComponent<Target>().GetHPValue;
            }
            time = (towerBlocksValue * 2) + (shieldValue * 5);
            timeForLevel = time;
            _initTime = time;
            _timeFor3star = (int)(time - (time * 0.7f));
            _timeFor2star = (int)(time - (time * 0.5f));
            _timeFor1star = (int)(time - (time * 0.3f));
        }
        private void OnEnable()
        {
            SystemActions.OnStartNewGame += StopTimer;
            SystemActions.OnStartNewGame += CalculateLevelTime;
            SystemActions.OnGetToMenuButtonClicked += StopTimer;
            SystemActions.OnLevelComplete += StopTimer;
            SystemActions.OnPlayerDie += StopTimer;
        }
    }
}