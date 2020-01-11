using System.Collections.Generic;

public class TilePool 
{
    private TileFactory _tileFactory;
    public Queue<TileView> poolQueue = new Queue<TileView>();

    public TilePool(TileFactory tileFactory)
    {
        _tileFactory = tileFactory;
    }

    public TileView GetObjectFromPool()
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
        poolQueue.Enqueue(_tileFactory.Create());
    }

}
