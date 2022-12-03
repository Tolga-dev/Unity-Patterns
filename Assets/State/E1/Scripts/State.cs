using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class State : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombieObj;
    private Zombie _zombie;
    void Start()
    {
        _zombie = new Zombie(zombieObj);
    }

    // Update is called once per frame
    void Update()
    {
        _zombie.UpdateStatus();
        
    }
}

namespace EnemyBase
{
    public class EnemyBase
    {
        protected GameObject Enemy;
        protected enum States
        {
            Attack,
            Walk,
            Jump
        }

        public virtual void UpdateStatus() { }

        protected void CurrentStateUpdate(States states)
        {
            switch (states)
            {
                case States.Attack:
                    Debug.Log("Attack!");
                    break;
                case States.Jump:
                    Debug.Log("Jump!");
                    break;
                case States.Walk:
                    Debug.Log("Walk!");
                    break;
                default:
                    break;        
            }
        }

    }
}

namespace Enemies
{
    public class Zombie : EnemyBase.EnemyBase
    {
        private States _states = States.Walk;

        public Zombie(GameObject Enemy)
        {
            base.Enemy = Enemy;
        }

        public override void UpdateStatus()
        {
            switch (_states)
            {
                case States.Attack:
                    // change state
                    break;
                case States.Jump:
                    break;
                case States.Walk:
                    break;
                default:
                    break;        
            }
            CurrentStateUpdate(_states);
            
        }
    }
}