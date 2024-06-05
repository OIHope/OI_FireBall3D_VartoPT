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
        }
        private void GameSet()
        {
            SystemActions.OnLevelComplete?.Invoke();
        }
    }
}