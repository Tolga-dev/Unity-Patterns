using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface ICommand
{
    public void Execute();
    public void ExecuteUndo();
}

public class Command : ICommand
{
    public GameObject GameObject;
    private readonly string _name;
    public Command(GameObject gameObject, string name)
    {
        this.GameObject = gameObject;
        this._name = name;
    }
    public void Execute()
    {
        GameObject.transform.position += Vector3.one;
        Debug.Log("Execute "  + _name );
    }
 
    public void ExecuteUndo()
    {
        GameObject.transform.position -= Vector3.one;
        Debug.Log("Undo "  + _name);
    }
}

public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mPlayer;
    public new string name;
    private ICommand _command;
    private readonly List<ICommand> _commandsBuffer = new List<ICommand>();

    private void Start()
    {
        _command = new Command(mPlayer, name);
        _command.Execute();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                ICommand newCommand = new Command(hit.collider.gameObject, name);
                AddCommandToBuffer(newCommand);
                newCommand.Execute();
            }
                
        }

        if (Input.GetKeyDown(KeyCode.R) )
        {
            Undo();
        }
    }

    private void Undo()
    {
        StartCoroutine(UndoRoutine());
    }

    private IEnumerator UndoRoutine()
    {
        foreach(var command in Enumerable.Reverse(_commandsBuffer))
        {
            command.ExecuteUndo();
            _commandsBuffer.Remove(command);
            yield return new WaitForSeconds(1.0f);
        }
        
    }

    private void AddCommandToBuffer(ICommand command)
    {
        _commandsBuffer.Add(command);
    }

}