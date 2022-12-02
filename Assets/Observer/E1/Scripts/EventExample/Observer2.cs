using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

interface IJob
{
    public void GetJob(int id, JobsTypes jobsTypes);
    
}
    

public class JobWorker : IJob
{
    public void GetJob(int id, JobsTypes jobsTypes)
    {}
    
}

public delegate void AssignJob();

public delegate void WorkPerforming(int id, JobsTypes jobsTypes);
public class Observer2 : MonoBehaviour
{
    private JobWorker _jobWorker;
    
    public static event AssignJob AssignableJob;
    
    public static event WorkPerforming Work;
    public static event EventHandler WorkCompleted;
    
    private void Start()
    {
        
        AssignableJob += new AssignJob(EngineerEvent);
        AssignableJob += new AssignJob(BuilderEvent);
        AssignableJob.Invoke();
        
    }

    static void DoJob(int id, JobsTypes jobsTypes)
    {
        Work?.Invoke(8, JobsTypes.Builder);
        
    }
    static void EngineerEvent()
    {
        Debug.Log(JobsTypes.Engineer);
    }
    static void BuilderEvent()
    {
        Debug.Log(JobsTypes.Builder);
    }
}

public enum JobsTypes
{
    Builder,
    Engineer
}

