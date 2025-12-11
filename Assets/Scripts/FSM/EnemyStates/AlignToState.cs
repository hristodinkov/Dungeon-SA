using UnityEngine;

public class AlignToState : State
{
    private Transform target;
    private Transform self;
    private Vector3 direction;
    private float rotationSpeed;
    private float rotationSign;
    private float targetRange;

    public AlignToState(Transform pSelf, Transform pTarget, float pRotationSpeed, float pTargetRange)
    {
        self = pSelf;
        SetTarget(pTarget);
        rotationSpeed = pRotationSpeed;
        targetRange = pTargetRange;

        stateName = "AlignTo";
    }
    public void SetTarget(Transform pTarget)
    {
        target = pTarget;
    }

    public override void Step()
    {
        base.Step();
        direction = (target.position - self.position).normalized;
        rotationSign = Mathf.Sign(Vector3.Dot(self.right, direction));

        self.Rotate(self.up, rotationSign * rotationSpeed * Time.deltaTime);
    }

    public bool AlignedWithTarget()
    {
        return Vector3.Dot(self.forward, direction) >= 0.4f;
    }

    public bool TargetOutOfRange()
    {
        return Vector3.Distance(self.position, target.position) > targetRange;
    }
}
