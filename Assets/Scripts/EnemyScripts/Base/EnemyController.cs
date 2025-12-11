using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{ 
    [SerializeField]
    private EnemyData enemyData;
    private Enemy enemy;

    public event Action<Enemy> onEnemyCreated;
    public event Action<Enemy, DamageData> onHit;

    void Start()
    {
        enemy = enemyData.CreateEnemy();
        onEnemyCreated?.Invoke(enemy);
    }

    private void Update()
    {
        
    }

    public void GetHit(DamageData damageData)
    {
        enemy.currentHP -= damageData.damage;
        if(enemy.currentHP < 0)
        {
            enemy.currentHP = 0;
        }

        onHit?.Invoke(enemy, damageData);
    }

    public void GetHitButton()
    {
        DamageData damageData= new DamageData(5);
        enemy.currentHP -= damageData.damage;
        if (enemy.currentHP < 0)
        {
            enemy.currentHP = 0;
        }

        onHit?.Invoke(enemy, damageData);
    }

    public bool IsDead()
    {
        return enemy.currentHP <= 0;
    }
}




