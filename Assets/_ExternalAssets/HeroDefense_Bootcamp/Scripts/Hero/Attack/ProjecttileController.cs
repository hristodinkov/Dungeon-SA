using UnityEngine;

/// <summary>
/// A projectile controller for the movement and hit detection of projectiles
/// from hero attacks.
/// </summary>
public class ProjectileController : MonoBehaviour
{
    private DamageData damageData;
    private Transform target;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float duration = 5f;

    private void Start()
    {
        Destroy(gameObject, duration);
    }
    public void SetUp(Transform pTarget, DamageData pDamageData)
    {
        target = pTarget;
        damageData = pDamageData;
    }

    void Update()
    {
        if(target != null)
        {
            Vector3 movement = (target.position - transform.position).normalized * speed * Time.deltaTime;
            transform.position += movement;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            if(enemyController != null)
            {
                enemyController.GetHit(damageData);
            }
        }
    }
}
