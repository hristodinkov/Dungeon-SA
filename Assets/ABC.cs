using UnityEngine;

public class ABC : MonoBehaviour
{
    public void OnEnemyDie(EventData eventData)
    {
        EnemyDieEventData enemyDieEventData = (EnemyDieEventData)eventData;
        print("money+" + enemyDieEventData.enemy.Money.ToString());
    }
}
