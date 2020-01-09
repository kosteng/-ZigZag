using System.Collections.Generic;

public class Pool 
{
    private Factory _factory;
    public Queue<ViewTile> poolQueue = new Queue<ViewTile>();

    public Pool(Factory factory)
    {
        _factory = factory;
    }

    public ViewTile GetObjectFromPool()
    {
        if (poolQueue.Count == 0)
        {
            GetObjectFromFactory();        
            return poolQueue.Dequeue();
        }
        else
        {
            return poolQueue.Dequeue();
        }   
    }

    private void GetObjectFromFactory()
    {
        poolQueue.Enqueue(_factory.CreateTile());
    }

}
