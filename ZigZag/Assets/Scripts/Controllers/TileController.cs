public class TileController 
{
    private readonly ViewTile _viewTile;
    private readonly Factory _factory;
    private readonly RoadBuilder _roadBuilder;

    public TileController (ViewTile viewTile, Factory factory, RoadBuilder roadBuilder)
    { 
        _viewTile = viewTile;
        _factory = factory;
        _roadBuilder = roadBuilder;
    }
    public void Start ()
    {
        _viewTile.Start();
        _roadBuilder.Coordinator();
        //for (int i = 0; i <= 5; i++)
           // _pool.poolStack.Push(_factory.Create());
    }
}
