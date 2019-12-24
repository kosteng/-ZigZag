using UnityEngine;

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
        _viewTile.Start();
        _roadBuilder.BuildStartingPlatform(1, 1);
        CreateRoad(80);
    }

    public void Update(float deltaTime)
    {
        _timer += deltaTime*2;
        if (_timer >= 5)
        {
            Debug.Log("Pool: " + _roadBuilder._pool.poolQueue.Count);
            _timer = 0;
            BackToPool();
            CreateRoad(50);
        }
    }

    private void BackToPool()
    {
        for (int i = 0; i < _roadBuilder.tilesOnScene.Count; i++)
        {
            if (_roadBuilder.tilesOnScene[i].use)
            {
                _roadBuilder.tilesOnScene[i].use = !_roadBuilder.tilesOnScene[i].use;
                _roadBuilder._pool.poolQueue.Enqueue(_roadBuilder.tilesOnScene[i]);
                _roadBuilder.RemoveAtToList(i);
            }
        }
    }

    private void CreateRoad(int count)
    {
        while (_roadBuilder.tilesOnScene.Count < count)
        {
            var rnd = Random.Range(0, 2);
            _roadBuilder.BuildRoad(1, rnd);
        }
    }
}
