using UnityEngine;

public abstract class PlayerObserver : MonoBehaviour
{
    [SerializeField]
    protected PlayerController playerController;

    protected void OnEnable()
    {
        playerController.onHit += OnHit;
    }
    
    protected void OnDisable()
    {
        playerController.onHit -= OnHit;
    }

    protected abstract void OnHit(DamageData damageData,PlayerData playerData);
}
