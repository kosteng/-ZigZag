using System.Collections.Generic;

public class TilePool 
{
    private TileFactory _tileFactory;
    public Queue<TileView> poolQueue = new Queue<TileView>();

    public TilePool(TileFactory tileFactory)
    {
        _tileFactory = tileFactory;
    }

    public TileView GetObject()
    {
        if (poolQueue.Count == 0)
        {
            poolQueue.Enqueue(_tileFactory.Create());
            return poolQueue.Dequeue();
        }
        else
        {
            return poolQueue.Dequeue();
        }   
    }

    public void Back (TileView tile)
    {
        poolQueue.Enqueue(tile);
    }

}
