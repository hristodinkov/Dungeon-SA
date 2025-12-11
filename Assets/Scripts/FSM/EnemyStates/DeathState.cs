using UnityEngine;
using UnityEngine.AI;

public class DeathState :State
{
    private readonly NavMeshAgent agent;
    private readonly EnemyController enemyController;

    public DeathState(NavMeshAgent agent, EnemyController enemyController)
    {
        this.agent = agent;
        this.enemyController = enemyController;
        if (this.enemyController != null)
        {
            this.enemyController.onHit += OnEnemyHit;
        }
    }

    private void OnEnemyHit(Enemy enemy, DamageData damageData)
    {
        if (enemy.currentHP <= 0)
        {
            agent.isStopped = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
        if (enemyController != null)
        {
            enemyController.onHit -= OnEnemyHit;
        }
    }


}
