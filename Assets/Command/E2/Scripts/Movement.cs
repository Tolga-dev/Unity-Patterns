using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    CommandE ForwardCommand;
    CommandE backCommandE;
    CommandE IdleCommandE;
    List<CommandE> StoredCommands = new List<CommandE>();
    void Start()
    {
        ForwardCommand = new Forward();
        backCommandE = new Back();
        IdleCommandE = new DoNothing();
    } 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            backCommandE.Execute(backCommandE);
            StoredCommands.Add(backCommandE);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ForwardCommand.Execute(ForwardCommand);
            StoredCommands.Add(ForwardCommand);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(GetUndo());
        }
    }

    IEnumerator GetUndo()
    {
        try
        {
            StoredCommands[StoredCommands.Count - 1].Undo();
            StoredCommands.RemoveAt(StoredCommands.Count - 1);
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
