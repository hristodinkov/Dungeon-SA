using UnityEngine;

/// <summary>
/// Catches and destroy GameObjects with a Collider.
/// </summary>
public class EnemyCatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
