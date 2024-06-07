using Assets.Script.Audio;

namespace Assets.Script.Level
{
    public class ShieldTargetManager : Target
    {
        public override void Init() { }
        protected override void Update() { }
        public override void MoveBlockDown(float modifyPos) { }
        public override void TakeDamage() => Damage();
        protected override void Damage()
        {
            animator.SetTrigger("TargetIsHit");
            SoundFXManager.instance.PlaySoundFX(hitClip, transform, 1f, true);
        }
        protected override void Destruction() { }
    }
}