using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
    private Transform target;
    private NavMeshAgent navMeshAgent;
    private float distanceThreshold;
    private float targetRange;

    public MoveState(Transform pTarget, NavMeshAgent pNavMeshAgent, float pDistanceThreshold, float pTargetRange)
    {
        target = pTarget;
        navMeshAgent = pNavMeshAgent;
        distanceThreshold = pDistanceThreshold;
        targetRange = pTargetRange;

        stateName = "MoveTo";
    }

    public override void Enter()
    {
        base.Enter();
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(target.position);
    }

    public override void Step()
    {
        base.Step();
        navMeshAgent.SetDestination(target.position);
    }

    public bool TargetReached()
    {
        float distanceToTarget = Vector3.Distance(navMeshAgent.transform.position, target.position);
        return distanceToTarget <= distanceThreshold;
    }

    public bool TargetOutOfRange()
    {
        float distanceToTarget = Vector3.Distance(navMeshAgent.transform.position, target.position);
        return distanceToTarget > targetRange;
    }

    public override void Exit()
    {
        base.Exit();
        navMeshAgent.isStopped = true;
    }

}
