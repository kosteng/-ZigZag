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
        if (this == null)
        {
            GetTileToFactory();        
            return poolStack.Pop();
        }
        else
        {
            GetTileToFactory();
            return poolStack.Pop();
        }

    }
    private void GetTileToFactory ()
    {
        poolStack.Push(_factory.Create());
    }

}
