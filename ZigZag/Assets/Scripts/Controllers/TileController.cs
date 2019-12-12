public class TileController 
{
    private readonly ViewTile _viewTile;
    private readonly Factory _factory;
    public TileController (ViewTile viewTile, Factory factory)
    { 
        _viewTile = viewTile;
        _factory = factory;
    }
    public void Start ()
    {
        _viewTile.Start();
        _factory.Create();
    }
}
