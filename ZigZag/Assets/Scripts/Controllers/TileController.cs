using UnityEngine;
public class TileController 
{
    private readonly ViewTile _viewTile;
    private readonly RoadBuilder _roadBuilder;

    public TileController (ViewTile viewTile, RoadBuilder roadBuilder)
    { 
        _viewTile = viewTile;
        _roadBuilder = roadBuilder;
    }
    
    public void Start()
    {
        var i = 0;
        _viewTile.Start();
        _roadBuilder.BuildStartingPlatform(1, 1);

        

        while (i < 100)
        {
            i++;
            var rnd = Random.Range(0, 2);
            _roadBuilder.BuildRoad(1, rnd);
        }
    }
}
