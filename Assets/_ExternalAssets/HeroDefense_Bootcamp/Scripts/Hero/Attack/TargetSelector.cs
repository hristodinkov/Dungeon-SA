using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Manages detection and selection of enemy targets within a trigger area.
/// Notifies listeners when enemies enter or exit the detection range.
/// </summary>
public class TargetSelector : MonoBehaviour
{
    /// <summary>
    /// Invoked when the first enemy enters the detection range.
    /// </summary>
    public Action OnTargetsFound;

    /// <summary>
    /// Invoked when the last enemy leaves or dies, clearing all targets.
    /// </summary>
    public Action OnTargetsGone;

    [SerializeField]
    private List<Transform> targets = new List<Transform>(); // Currently tracked enemy targets

    /// <summary>
    /// Returns the current target (first in the list).
    /// Returns null if there are no targets.
    /// </summary>
    public Transform GetTarget()
    {
        if (targets.Count == 0)
            return null;
        else
        {
            return targets[0];
        }
    }

    /// <summary>
    /// Removes a target from the list when it dies, this is an implementation of the event bus
    /// pattern, it subscribes the EnemyDieEvent(a scriptable object)
    /// </summary>
    /// <param name="eventData">Event data containing the dead enemy's transform.</param>
    public void OnTargetDied(EventData eventData)
    {
        EnemyDieEventData enemyDieEventData = (EnemyDieEventData)eventData;
        targets.Remove(enemyDieEventData.enemyObject.transform);
    }

    /// <summary>
    /// Called by Unity when a collider enters the trigger zone.
    /// Adds enemy targets to the list and triggers OnTargetsFound if it's the first.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // If no enemies were tracked before, notify listeners
            if (targets.Count == 0)
            {
                OnTargetsFound?.Invoke();
            }

            // Add the new enemy to the list
            targets.Add(other.transform);
        }
    }

    /// <summary>
    /// Called by Unity when a collider exits the trigger zone.
    /// Removes the enemy from the list and triggers OnTargetsGone if none remain.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Remove(other.transform);

            // If all enemies are gone, notify listeners
            if (targets.Count == 0)
            {
                OnTargetsGone?.Invoke();
            }
        }
    }
}