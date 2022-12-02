using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Jobs
{
    _nightWatchman,
    _laborer
}

public interface IWorker  
{
    public delegate void Work(int id, Jobs type);

    public void WorkManager(int id, Jobs type);

}

public class Worker : IWorker
{
    public void WorkManager(int id, Jobs type)
    {
        Debug.Log(" Work ID " + id);
    }
    public void DoJOb(IWorker.Work Job)
    {
        Job(15, Jobs._nightWatchman);
    }
}

public class Observer : MonoBehaviour
{
    private Worker _worker;

    private void Start()
    {
        _worker = new Worker();
        IWorker.Work workType = new IWorker.Work(_worker.WorkManager);
        
        _worker.DoJOb(workType);
         workType.Invoke(1, Jobs._laborer);
        
    }
    
    
 
}
