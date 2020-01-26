using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadBuilder 
{
    private bool _direction = true;
    private Vector3 _lostPosition;
    private readonly TilePool _tilePool;
    public List<TileView> tilesOnScene;
    
    public RoadBuilder (TilePool tilePool)
    {
        tilesOnScene = new List<TileView>();
        _tilePool = tilePool;
    }

    public void BuildStartingPlatform(int countX, int countZ)
    {
        for (int x = -countX; x <= countX; x++)
            for (int z = -countZ; z <= countZ; z++)
            {
                tilesOnScene.Add(_tilePool.GetObject());
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
                _tilePool.Back(tilesOnScene[i]); 
                tilesOnScene.RemoveAt(i);
            }
        }
    }

    public void CreateRoad(int countTiles)
    {
        while (tilesOnScene.Count < countTiles)
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
                _lostPosition.z++;
            }
            else
            {
                _lostPosition.x++;
            }
            tilesOnScene.Add(_tilePool.GetObject());
            tilesOnScene.LastOrDefault().transform.position = _lostPosition;
            if (i == rndCoint)
            {
                tilesOnScene.LastOrDefault().transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
