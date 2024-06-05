using System;
using UnityEngine;

namespace Assets.Script.Level
{
    public abstract class Target : MonoBehaviour
    {
        public System.Action OnDestroyAction;
        [SerializeField] protected Animator animator;
        [SerializeField] protected TMPro.TextMeshPro hpText;
        [SerializeField] protected int maxHp;
        protected int hp;
        protected Vector3 _currentPos;

        public int GetHPValue => maxHp;
        public virtual void TakeDamage()
        {
            if (hp > 0) Damage();
            if (hp <= 0) Destruction();
        }
        public virtual void Init()
        {
            hp = maxHp;
            _currentPos = transform.position;
            ChangeText(hp);
        }
        public virtual void MoveBlockDown(float modifyPos)
        {
            _currentPos = new Vector3(_currentPos.x, _currentPos.y - modifyPos, _currentPos.z);
        }
        protected virtual void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _currentPos, 10f * Time.deltaTime);
        }
        protected void ChangeText(int hp)
        {
            hpText.text = hp.ToString();
        }
        protected virtual void Damage()
        {
            hp--;
            animator.SetTrigger("TargetIsHit");
            ChangeText(hp);
        }
        protected virtual void Destruction()
        {
            OnDestroyAction?.Invoke();
            animator.SetTrigger("TargetIsDead");
            OnDestroyAction = null;
        }
    }
}