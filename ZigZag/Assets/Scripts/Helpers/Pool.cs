using System.Collections.Generic;
using UnityEngine;
public class Pool 
{
    private Factory _factory;
    public Queue<ViewTile> poolQueue = new Queue<ViewTile>();
    public Pool (Factory factory)
    {
        _factory = factory;
    }
    public ViewTile GetTile ()
    {

        if (poolQueue.Count == 0)
        {
            GetTileFromFactory();        
            return poolQueue.Dequeue();
        }
        else
        {
            return poolQueue.Dequeue();
        }
        
    }
    private void GetTileFromFactory()
    {
        poolQueue.Enqueue(_factory.CreateTile());
    }

}
