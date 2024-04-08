using System;
using UnityEngine;

namespace Observer.E2.Scripts
{
    public class Observer : MonoBehaviour
    {

        public event EventHandler myEvent;
        

    }

    public class Timer : EventArgs
    {
        
    }
}