using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadBuilder 
{
    private TileFactory _tileFactory;
    private bool _direction = true;
    private Vector3 _lostPosition;
    private TilePool _tilePool;
    public List<TileView> tilesOnScene;
    
    public RoadBuilder (TilePool tilePool, TileFactory factory)
    {
        tilesOnScene = new List<TileView>();
        _tilePool = tilePool;
        _tileFactory = factory;
    }

    public void BuildStartingPlatform(int countX, int countZ)
    {
        for (int x = -countX; x <= countX; x++)
            for (int z = -countZ; z <= countZ; z++)
            {
                tilesOnScene.Add(GetTileFromPool());
                tilesOnScene.LastOrDefault().transform.position = new Vector3(x, 0, z);
                _lostPosition = tilesOnScene.LastOrDefault().transform.position;                
            }
    }

    public void SetDirectionRoad(int count)
    {
        SetPositionTiles(count, _direction);
        _direction = !_direction;
    }

    public void BackToPool()
    {
        for (int i = 0; i < tilesOnScene.Count; i++)
        {
            if (tilesOnScene[i].use)
            {
                tilesOnScene[i].use = !tilesOnScene[i].use;
                tilesOnScene[i].transform.GetChild(0).gameObject.SetActive(false);
                _tilePool.poolQueue.Enqueue(tilesOnScene[i]);
                tilesOnScene.RemoveAt(i);
            }
        }
    }

    public void CreateRoad(int countTiles)
    {
        while (tilesOnScene.Count < countTiles)
        {
            var rndCountTile = Random.Range(1, 5);
            SetDirectionRoad(rndCountTile);
        }
    }
    private TileView GetTileFromPool()
    {
        return _tilePool.GetObjectFromPool();
    }

    private void SetPositionTiles(int countTiles, bool direction)
    {
        var rndCoint = Random.Range(1, countTiles);
        for (int i = 1; i <= countTiles; i++)
        {
            if (direction)
                _lostPosition.z++;
            else
                _lostPosition.x++;
            tilesOnScene.Add(GetTileFromPool());
            tilesOnScene.LastOrDefault().transform.position = _lostPosition;
            if (i == rndCoint)
                tilesOnScene.LastOrDefault().transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
