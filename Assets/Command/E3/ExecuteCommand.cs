using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteCommand : MonoBehaviour
{
    public Player plObject;

    // all commands
    private IInputCommand up_command;
    private IInputCommand down_command;
    private IInputCommand left_command;
    private IInputCommand right_command;
    private IInputCommand shoot_command;

    // the shoot rate
    private float _flShootRate;
    // flag who indicates if player can do some commands
    private bool _boolCanMove;

    private void Awake()
    {
        up_command = new RunUp_Command();
        down_command = new RunBack_Command();
        left_command = new RotateLeft_Command();
        right_command = new RotateRight_Command();
        shoot_command = new Shoot_Command();
        
        throw new NotImplementedException();
    }

    private void Start()
    {
        _flShootRate = 10; 
    }

    private void Update()
    {   
        if (Input.GetKey(KeyCode.UpArrow))
            up_command.Execute(plObject);
        else if (Input.GetKey(KeyCode.DownArrow))
            down_command.Execute(plObject);

        if (Input.GetKey(KeyCode.RightArrow))
            right_command.Execute(plObject);
        else if (Input.GetKey(KeyCode.LeftArrow))
            left_command.Execute(plObject);

        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.frameCount % _flShootRate == 0)
                shoot_command.Execute(plObject);
        }
        
    
    }
    
}
