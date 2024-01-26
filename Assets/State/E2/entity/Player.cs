using System;
using UnityEngine;

public class Player2 : Entity
{
    private void Awake()
    {
        StateMachine = new stateMachine(this);
        StateMachine.stateChanged += OnStateChanged;
    }
    
    private void OnStateChanged(IState state)
    {
        Debug.Log("state changed to " + state.GetType().Name);
    }
    void OnDestroy()
    {
        // unregister the subscription if we destroy the object
        StateMachine.stateChanged -= OnStateChanged;
    }
}