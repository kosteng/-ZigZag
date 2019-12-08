public class TileController 
{
    private readonly ViewTile _viewTile;
    public TileController (ViewTile viewTile)
    {
        _viewTile = viewTile;
    }
    public void Start ()
    {
        _viewTile.Generate();
    }
}
