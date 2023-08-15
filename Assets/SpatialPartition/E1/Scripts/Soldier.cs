using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier
{
    public Transform SoldierTransform;

    public float WalkSpeed;

    public Soldier NextSoldier;
    public Soldier PrevSoldier;
    
    public virtual void Move() {}
    public virtual void Move(Soldier soldier) {}
    
    
    

}

