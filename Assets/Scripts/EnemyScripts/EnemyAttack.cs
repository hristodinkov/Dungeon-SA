using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            PlayerController playerData = other.gameObject.GetComponent<PlayerController>();
            DamageData damageData = new DamageData(10);

            if (playerData != null)
            {
                playerData.GetHit(damageData);
            }
        }
    }
}
