using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public static event Action TakeHealth;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TakeHealth?.Invoke();
            Debug.Log("A");
        }
    }
    
}
