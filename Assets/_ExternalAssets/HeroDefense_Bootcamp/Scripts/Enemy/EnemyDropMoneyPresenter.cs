using UnityEngine;
using TMPro;

/// <summary>
/// Subscribes to EnemyDieEvent and display dropped money number where the enemy dies. 
/// </summary>
public class EnemyDropMoneyPresenter : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro moneyTextPrefab;
    [SerializeField]
    private float displayTime = 0.5f;

    public void DisplayMoneyText(EventData eventData)
    {
        EnemyDieEventData enemyDieEventData = (EnemyDieEventData)eventData;
        TextMeshPro moneyText = Instantiate(moneyTextPrefab);
        moneyText.transform.position = enemyDieEventData.enemyObject.transform.position
            +Vector3.up;
        moneyText.text = "+$" + enemyDieEventData.enemy.Money.ToString();
        Destroy(moneyText.gameObject, displayTime);
    }
}
