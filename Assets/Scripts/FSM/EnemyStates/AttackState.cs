using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    private float attackDuration;
   
    private float attackStartTime;
    private NavMeshAgent navMeshAgent;
    private Collider attackCollider;
    public AttackState(float eAttackDuration,NavMeshAgent eNavMeshAgent, Collider attackCollider)
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
        float timeToTurnOnCollider = 1f;
        //while (Time.time < attackStartTime + timeToTurnOnCollider)
        //{
        //    //wait
        //}
        attackCollider.enabled = true;
    }

    public override void Exit()
    {
        base.Exit();
        attackCollider.enabled = false;
    }

    //--------Helper Condition for Transitions to decide whether to transition to the next state
    public bool AttackOver()
    {
        navMeshAgent.isStopped = false;
        
        return Time.time > attackStartTime + attackDuration;
    }

    


}
