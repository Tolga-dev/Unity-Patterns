using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State5 : StateMachine
{

    private void Start()
    {
    }

    public void OnWalk()
    {
        //StartCoroutine(MainState.Walk());
    }
    public void OnRun()
    {
      //  StartCoroutine(MainState.Run());
    }
}

public abstract class MainState
{
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator Walk()
    {
        yield break;
    }    
    
    public virtual IEnumerator Run()
    {
        yield break;
    }

}

public abstract class StateMachine : MonoBehaviour
{
    protected MainState _state;

    public void SetState(MainState state)
    {
        _state = state;
        StartCoroutine(_state.Start());
    }
    
}