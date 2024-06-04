using Assets.Script.Level;

namespace Assets.Script.Player
{
    public class PlayerTargetManager : Target
    {
        private void Start()
        {
            ChangeText(hp);
        }
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
            base.Destruction();
        }
        protected override void Update()
        {
        }
    }
}