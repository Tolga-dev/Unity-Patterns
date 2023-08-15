using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public Rigidbody _myRigidBody;
    
    private Transform _myTransform;
    private float _flVertical;
    private float _flHorizontal;
    private float _flRotateMultiplier = 3;
    
    void Awake()
    {
        _myTransform = transform;
        _myRigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    { 
    }

    public void RunForward()
    {
        _flHorizontal = 0;
        _flVertical = 1f;
        _myRigidBody.velocity = _myTransform.forward * _flVertical;
    }

    public void RunBack()
    {
        _flHorizontal = 0;
        _flVertical = -1f;
        _myRigidBody.velocity = _myTransform.forward * _flVertical;
    }
    public void RotateRight()
    {
        _flVertical = 0;
        _flHorizontal = 1f;
        _myTransform.Rotate(0, _flHorizontal * _flRotateMultiplier, 0);
    }
    
    public void RotateLeft()
    {
        _flVertical = 0;
        _flHorizontal = -1f;
        _myTransform.Rotate(0, _flHorizontal * _flRotateMultiplier, 0);
    }

    public void Shoot()
    {
        // Shooting
    }

    
}
