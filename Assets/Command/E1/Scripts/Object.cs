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
    public GameObject gameObject;
    private string name;
    public Command(GameObject gameObject, string name)
    {
        this.gameObject = gameObject;
        this.name = name;
    }
    public void Execute()
    {
        gameObject.transform.position += Vector3.one;
        Debug.Log("Execute "  + name );
    }
 
    public void ExecuteUndo()
    {
        gameObject.transform.position -= Vector3.one;
        Debug.Log("Undo "  + name);
    }
}

public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mPlayer;
    public string name;
    private ICommand command;
    private List<ICommand> _commandsBuffer = new List<ICommand>();
    void Start()
    {
        command = new Command(mPlayer, name);
        command.Execute();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
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

    IEnumerator UndoRoutine()
    {
        foreach(var command in Enumerable.Reverse(_commandsBuffer))
        {
            command.ExecuteUndo();
            _commandsBuffer.Remove(command);
            yield return new WaitForSeconds(1.0f);
        }
        
    }

    void AddCommandToBuffer(ICommand command)
    {
        _commandsBuffer.Add(command);
    }

}