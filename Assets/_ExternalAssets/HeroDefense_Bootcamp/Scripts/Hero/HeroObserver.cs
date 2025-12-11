using UnityEngine;

public abstract class HeroObserver : MonoBehaviour
{
    [SerializeField]
    protected HeroModel heroController;

    protected void OnEnable()
    {
        heroController.onLevelUp += OnLevelUp;
    }

    protected void OnDisable()
    {
        heroController.onLevelUp -= OnLevelUp;
    }

    protected abstract void OnLevelUp(int currentLevel);
}
