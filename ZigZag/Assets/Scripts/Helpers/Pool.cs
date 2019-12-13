using System.Collections.Generic;
using UnityEngine;
public class Pool 
{
    private Factory _factory;
    public Stack<GameObject> poolStack = new Stack<GameObject>();
    public Pool (Factory factory)
    {
        _factory = factory;
    }
    public GameObject GetTile ()
    {
        GetTileFromFactory();
        GetTileFromFactory();
        if (this == null)
        {
            GetTileFromFactory();        
            return poolStack.Pop();
        }
        else
        {
            return poolStack.Pop();
        }
        
    }
    private void GetTileFromFactory()
    {
        poolStack.Push(_factory.Create());
    }

}
