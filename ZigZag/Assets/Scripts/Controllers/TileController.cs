using UnityEngine;
using System.Linq;
public class TileController 
{
    private readonly ViewTile _viewTile;
    private readonly RoadBuilder _roadBuilder;
    private float _timer = 0;

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
    public void Update(float deltaTime)
    {
        _timer += deltaTime*2;
        if (_timer >= 5)
        {
            Debug.Log("Pool: " + _roadBuilder._pool.poolStack.Count);
           // Debug.Log("Objects scene: " + _roadBuilder.tilesOnScene.Count);
            var j = 0;
            _timer = 0;
            for (int i = 0; i < _roadBuilder.tilesOnScene.Count; i++)
            {
                if (_roadBuilder.tilesOnScene[i].use)
                {
                    _roadBuilder.tilesOnScene[i].use = !_roadBuilder.tilesOnScene[i].use;
                    _roadBuilder._pool.poolStack.Push(_roadBuilder.tilesOnScene[i]);
                    _roadBuilder.RemoveAtToList(i);                 
                }
            }

            while (j < 1)
            {
                j++;
                var rnd = Random.Range(0, 2);
                _roadBuilder.BuildRoad(1, rnd);
            }
        }
    }
}
