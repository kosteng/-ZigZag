public class TileController 
{
    private readonly ViewTile _viewTile;
    private readonly Factory _factory;
    private readonly Pool _pool;
    public TileController (ViewTile viewTile, Factory factory, Pool pool)
    { 
        _viewTile = viewTile;
        _factory = factory;
        _pool = pool;
    }
    public void Start ()
    {
    //    _viewTile.Start();
    //    for (int i = 0; i <= 5; i++)
            _pool.AddObject(_factory.Create());
    }
}
