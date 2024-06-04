using Assets.Script.Level;
using UnityEditor;

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
            animator.SetTrigger("TargetIsDead");
        }
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