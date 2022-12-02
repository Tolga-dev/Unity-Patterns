using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer3 : MonoBehaviour
{
    public int health = 100;

    private void OnEnable()
    {
        Debug.Log("On Enable");
        Health.TakeHealth += GetHealth;
    }
    private void OnDisable()
    {
        Debug.Log("On Disable");
        Health.TakeHealth -= GetHealth;
    }

    public void GetHealth()
    {
        health += 10;
    }

}
