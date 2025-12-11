using UnityEngine;
using System;

/// <summary>
/// Publishes the onValueChanged event whenever the value has changed.
/// Observers of this ScriptableObject gets notified only when the value has
/// changed.
/// </summary>
[CreateAssetMenu(fileName = "IntValue", menuName = "Scriptable Objects/IntValue")]
public class IntValue : ScriptableObject
{
    /// <summary>
    /// The initial value will be used to reset value when the game runs,
    /// otherwise the value is saved across sessions.
    /// </summary>
    [SerializeField]
    private int initialValue;

    //Whenever value is changed, it invoke the onValueChanged event to notify
    //all the subscribers, this is a very basic use of observer pattern
    private int _value;
    public int value
    {
        set
        {
            if (_value != value)
            {
                _value = value;
                onValueChanged?.Invoke();
            }
        }
        get => _value;
    }
    public event Action onValueChanged;

    private void OnEnable()
    {
        value = initialValue;
    }
}
