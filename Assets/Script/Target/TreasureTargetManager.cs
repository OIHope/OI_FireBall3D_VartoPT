using Assets.Script.Audio;
using Assets.Script.compAction;
using UnityEngine;

namespace Assets.Script.Level
{
    public class TreasureTargetManager : Target
    {
        protected override void Destruction()
        {
            Invoke("GameSet", 1f);
            animator.SetTrigger("TargetIsDead");
            foreach (GameObject particle in destroyParticles) { Instantiate(particle, transform.position, Quaternion.identity); }
            OnDestroyAction = null;
            SoundFXManager.instance.PlaySoundFX(destroyClip, transform, 1f, true);
        }
        private void GameSet()
        {
            SystemActions.OnLevelComplete?.Invoke();
        }
    }
}