using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadBuilder 
{
    private bool _direction = true;
    private Vector3 _lastPosition;
    private readonly TilePool _tilePool;
    public List<TileView> TilesOnScene;
    public int Count => TilesOnScene.Count;
    public RoadBuilder (TilePool tilePool)
    {
        TilesOnScene = new List<TileView>();
        _tilePool = tilePool;
    }

    public void BuildStartingPlatform(int sizeStartingPlatform)
    {
        for (int x = -sizeStartingPlatform; x <= sizeStartingPlatform; x++)
            for (int z = -sizeStartingPlatform; z <= sizeStartingPlatform; z++)
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
            if (!TilesOnScene[i].UseTile) return;
            TilesOnScene[i].UseTile = !TilesOnScene[i].UseTile;
			TilesOnScene[i].CoinOnTile.SetActive(false);
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
  
    private void SetPositionTiles(int countTiles, bool isUp)
    {
        var randomPositionCoinFromTile = Random.Range(1, countTiles);
        for (int i = 1; i <= countTiles; i++)
        {
             _lastPosition += isUp ? Vector3.forward : Vector3.right;          
            var tile = _tilePool.GetObject();
            tile.transform.position = _lastPosition; 
            if (i == randomPositionCoinFromTile) 
				tile.CoinOnTile.SetActive(true);      
			TilesOnScene.Add(tile);
		}
    }
}
