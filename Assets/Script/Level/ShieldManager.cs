using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Level
{
    public class ShieldManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private int difficultyValue;

        public int GetDifficultyValue => difficultyValue;
        public void Init()
        {
            int animationID = Random.Range(0, 3); // максимальне значення треба якось автоматизувати
            animator.SetFloat("RotationState", animationID);
        }
    }
}