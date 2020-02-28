using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadBuilder 
{
    private bool _direction = true;
    private Vector3 _lastPosition;
    private readonly TilePool _tilePool;
    public List<TileView> TilesOnScene;
    
    public RoadBuilder (TilePool tilePool)
    {
        TilesOnScene = new List<TileView>();
        _tilePool = tilePool;
    }

    public void BuildStartingPlatform(int countX, int countZ)
    {
        for (int x = -countX; x <= countX; x++)
            for (int z = -countZ; z <= countZ; z++)
            {
                var tile = _tilePool.GetObject();
                tile.transform.position = new Vector3(x, 0, z);
                _lastPosition = tile.transform.position;
                TilesOnScene.Add(tile);
            }
    }

    public void SetDirectionRoad(int count)
    {
        SetPositionTiles(count, _direction);
        _direction = !_direction;
    }

    public void BackToPool()
    {
        for (int i = 0; i < TilesOnScene.Count; i++)
        {
            if (!TilesOnScene[i].Use) return;
            TilesOnScene[i].Use = !TilesOnScene[i].Use;
			TilesOnScene[i].Coin.SetActive(false);
            _tilePool.Back(TilesOnScene[i]); 
            TilesOnScene.RemoveAt(i);           
        }
    }

    public void CreateRoad(int countTiles)
    {
        while (TilesOnScene.Count < countTiles)
        {
            int rndCountTile = Random.Range(1, 6);
            SetDirectionRoad(rndCountTile);
        }
    }
  
    private void SetPositionTiles(int countTiles, bool direction)
    {
        var rndCoint = Random.Range(1, countTiles);
        for (int i = 1; i <= countTiles; i++)
        {
            if (direction)
            {
                _lastPosition.z++;
            }
            else
            {
                _lastPosition.x++;
            }
            var tile = _tilePool.GetObject();

            tile.transform.position = _lastPosition;
            
            if (i == rndCoint)
            {
				tile.Coin.SetActive(true);
            }
			TilesOnScene.Add(tile);
		}
    }
}
