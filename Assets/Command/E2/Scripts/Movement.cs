using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private CommandE _forwardCommand;
    private CommandE _backCommandE;
    private CommandE _idleCommandE;
    private readonly List<CommandE> _storedCommands = new List<CommandE>();

    private void Start()
    {
        _forwardCommand = new Forward();
        _backCommandE = new Back();
        _idleCommandE = new DoNothing();
    } 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _backCommandE.Execute(_backCommandE);
            _storedCommands.Add(_backCommandE);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _forwardCommand.Execute(_forwardCommand);
            _storedCommands.Add(_forwardCommand);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(GetUndo());
        }
    }

    private IEnumerator GetUndo()
    {
        try
        {
            _storedCommands[^1].Undo();
            _storedCommands.RemoveAt(_storedCommands.Count - 1);
        }
        catch (Exception e)
        {
            Debug.Log("Index was out of range!");
            Console.WriteLine(e);
            throw;
        }
        yield return new WaitForSeconds(1.0f);
    }
}
