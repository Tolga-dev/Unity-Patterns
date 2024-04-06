using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State2 : MonoBehaviour
{
    private INpc _currentState;
    public readonly WanderState WanderState = new WanderState();
    
    void Start()
    {
        _currentState = WanderState;
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.ActionState(this);
    }
}

public interface INpc
{
    INpc ActionState(State2 npc);
}

public class WanderState : INpc
{
    public INpc ActionState(State2 npc)
    {
        return npc.WanderState;
    }
}
