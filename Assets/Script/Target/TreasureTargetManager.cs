using Assets.Script.Audio;
using Assets.Script.compAction;

namespace Assets.Script.Level
{
    public class TreasureTargetManager : Target
    {
        protected override void Destruction()
        {
            Invoke("GameSet", 1f);
            animator.SetTrigger("TargetIsDead");
            OnDestroyAction = null;
            SoundFXManager.instance.PlaySoundFX(destroyClip, transform, 1f, true);
        }
        private void GameSet()
        {
            SystemActions.OnLevelComplete?.Invoke();
        }
    }
}