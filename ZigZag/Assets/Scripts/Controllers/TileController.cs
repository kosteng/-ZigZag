using UnityEngine;

public class TileController 
{
    private readonly RoadBuilder _roadBuilder;
    private float _timer = 0;

    public TileController (RoadBuilder roadBuilder)
    { 
        _roadBuilder = roadBuilder;
    }
    
    public void Start()
    {
        _roadBuilder.BuildStartingPlatform(1, 1);
        CreateRoad(80);
    }

    public void Update(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer >= 5)
        {
            Debug.Log("Pool: " + _roadBuilder.poolTile.poolQueue.Count);
            _timer = 0;
            BackToPool();
            CreateRoad(80);
        }
    }

    private void BackToPool()
    {
        for (int i = 0; i < _roadBuilder.tilesOnScene.Count; i++)
        {
            if (_roadBuilder.tilesOnScene[i].use)
            {
                _roadBuilder.tilesOnScene[i].use = !_roadBuilder.tilesOnScene[i].use;
                _roadBuilder.poolTile.poolQueue.Enqueue(_roadBuilder.tilesOnScene[i]);
                _roadBuilder.RemoveAtToList(i);
            }
        }
    }

    private void CreateRoad(int count)
    {
        while (_roadBuilder.tilesOnScene.Count < count)
        {
            var rndDirection = Random.Range(0, 2);
            var rndCountTile = Random.Range(1, 5);
            _roadBuilder.BuildRoad(rndCountTile);
        }
    }
}
