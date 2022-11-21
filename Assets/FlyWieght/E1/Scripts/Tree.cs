using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTree
{
    public List<Vector3> LeafPosition;
}
 
public class Tree : MonoBehaviour
{
    SubTree Stree;
    public List<SubTree> AllTrees = new List<SubTree>();
    
    public int DensityOfLeaf;
    public int PosLeaf;
    
    void Start()
    {
        Stree = new SubTree();
        Stree.LeafPosition = GetLeafsPosition();
        
        for (int i = 0; i < DensityOfLeaf; i++)
        {
            SubTree tree = new SubTree();
            tree.LeafPosition = Stree.LeafPosition;
        }
    }
    
    List<Vector3> GetLeafsPosition()
    {
        List<Vector3> LeafsPos = new List<Vector3>();

        for (int i = 0; i < PosLeaf; i++)
        {
            LeafsPos.Add(new Vector3());
        }

        return LeafsPos;
    }
    

}
