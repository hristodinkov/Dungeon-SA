using UnityEngine;

/// <summary>
/// A simple money controller that subscribes to the EnemyDieEvent and
/// changes money when enemy dies
/// </summary>
public class MoneyController : MonoBehaviour
{
    [SerializeField]
    IntValue money;

    public void OnEnemyDied(EventData eventData)
    {
        EnemyDieEventData enemyDieEvent = (EnemyDieEventData)eventData;
        UpdateMoney(enemyDieEvent.enemy.Money);
    }

    private void UpdateMoney(int pValue)
    {
        money.value += pValue;
    }

}
