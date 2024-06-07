using Assets.Script.compAction;
using Assets.Script.Level;
using System;
using UnityEngine;

namespace Assets.Script.Player
{
    public class PlayerTargetManager : Target
    {
        public override void Init()
        {
        }
        public override void MoveBlockDown(float modifyPos)
        {
        }
        public override void TakeDamage()
        {
            base.TakeDamage();
        }
        protected override void Damage()
        {
            base.Damage();
        }
        protected override void Destruction()
        {
            Invoke("PlayerDie", 1f);
            animator.SetTrigger("TargetIsDead");
            foreach (GameObject particle in destroyParticles) { Instantiate(particle, transform.position, Quaternion.identity); }
        }
        private void PlayerDie() => SystemActions.OnPlayerDie?.Invoke();
        protected override void Update()
        {
        }
        private void OnEnable()
        {
            hp = maxHp;
            ChangeText(hp);
        }
    }
}