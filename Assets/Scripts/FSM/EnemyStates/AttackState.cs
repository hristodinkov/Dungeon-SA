using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    private float attackDuration;
    private float attackStartTime;
    private float colliderDelay = 0.5f;

    private NavMeshAgent navMeshAgent;
    private Collider attackCollider;

    private bool colliderActivated;

    public AttackState(float eAttackDuration, NavMeshAgent eNavMeshAgent, Collider attackCollider)
    {
        attackDuration = eAttackDuration;
        navMeshAgent = eNavMeshAgent;
        stateName = "Attack";
        this.attackCollider = attackCollider;
    }

    public override void Enter()
    {
        base.Enter();

        navMeshAgent.isStopped = true;

        attackStartTime = Time.time;
        colliderActivated = false;

        attackCollider.enabled = false;
    }

    public override void Step()
    {
        float elapsed = Time.time - attackStartTime;

        if (!colliderActivated && elapsed >= colliderDelay)
        {
            colliderActivated = true;
            attackCollider.enabled = true;
        }
    }

    public override void Exit()
    {
        base.Exit();

        attackCollider.enabled = false;
        navMeshAgent.isStopped = false;
    }

    public bool AttackOver()
    {
        return Time.time > attackStartTime + attackDuration;
    }


}
