using UnityEngine;

public class LevelUpVFXController : HeroObserver
{
    [SerializeField] private ParticleSystem levelUpParticleEffect;
    protected override void OnLevelUp(int currentLevel)
    {
        levelUpParticleEffect.Play();
    }

    
}
