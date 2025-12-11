using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class EnemyMoveBehaviour : MonoBehaviour
{
    //Sub-classes can use this to check if target is reached.
    [SerializeField]
    protected float targetRange = 0.2f;


    protected virtual void Start()
    {
        mAnimator = GetComponent<Animator>();
        PlayIdleAnimation();
    }

    public virtual void SetTargetPosition(Vector3 position)
    {
        PlayMovingAnimation();
    }


    #region "animation related fields"
    [SerializeField]
    private Animator mAnimator;

    protected virtual void PlayMovingAnimation()
    {
        mAnimator.SetBool("IsMoving", true);
    }

    protected virtual void PlayIdleAnimation()
    {
        mAnimator.SetBool("IsMoving", false);
    }
    #endregion
}
