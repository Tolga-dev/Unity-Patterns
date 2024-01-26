using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public static event Action TakeHealth;
    public static event Action TakeSlowness;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TakeHealth?.Invoke();
            TakeSlowness?.Invoke();
            Debug.Log("A");
        }
    }
    
}
