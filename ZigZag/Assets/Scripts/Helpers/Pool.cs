using System.Collections.Generic;
using UnityEngine;
public class Pool 
{
    private Factory _factory;
    public Stack<ViewTile> poolStack = new Stack<ViewTile>();
    public Pool (Factory factory)
    {
        _factory = factory;
    }
    public ViewTile GetTile ()
    {

        if (poolStack.Count == 0)
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
