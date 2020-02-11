using System.Collections.Generic;

public class TilePool 
{
    private TileFactory _tileFactory;
    public Queue<TileView> PoolQueue = new Queue<TileView>();

    public TilePool(TileFactory tileFactory)
    {
        _tileFactory = tileFactory;
    }

    public TileView GetObject()
    {
        if (PoolQueue.Count > 0)       
            return PoolQueue.Dequeue();
        return _tileFactory.Create();      
    }

    public void Back(TileView tile)
    {
        PoolQueue.Enqueue(tile);
    }

}
