using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State2 : MonoBehaviour
{
    // Start is called before the first frame update
    private INpc currentState;
    public readonly WanderState WanderState = new WanderState();
    void Start()
    {
        currentState = WanderState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.ActionState(this);
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
        // if else switch;
        return npc.WanderState;
    }
 

}
