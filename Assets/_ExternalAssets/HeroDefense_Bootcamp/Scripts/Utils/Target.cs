using UnityEngine;

/// <summary>
/// Attached to the navmesh system's target and save its position as a static value
/// for easy access.
/// </summary>
public class Target : MonoBehaviour
{
    public static Vector3 targetPosition;
    private void Awake()
    {
        targetPosition = transform.position;
    }
}
