using System;
using UnityEngine;

public class Transition 
{
    // A function delegate that returns true when the transition condition is met.
    // This is evaluated in Step() by states to check if the FSM should switch states.
    public Func<bool> condition;
    // The state to transition to if the condition returns true.
    public State nextState;

    // Constructor to create a new transition.
    public Transition(Func<bool> pCondition, State pNextState)
    {
        condition = pCondition;
        nextState = pNextState;
    }
}
