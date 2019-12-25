using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadBuilder 
{
    private bool _direction = true;
    private Vector3 _lostPosition;
    public Pool poolTile;
    public Pool poolCoin;
    public List<ViewTile> tilesOnScene;
    
    public RoadBuilder (Pool poolTile, Pool poolCoin)
    {
        tilesOnScene = new List<ViewTile>();
        this.poolTile = poolTile;
        this.poolCoin = poolCoin;
    }

    public ViewTile Build ()
    {
        return poolTile.GetTile();
    }

    public void BuildStartingPlatform(int countX, int countZ)
    {
        for (int x = -countX; x <= countX; x++)
            for (int z = -countZ; z <= countZ; z++)
            {
                tilesOnScene.Add(Build());
                tilesOnScene.LastOrDefault().transform.position = new Vector3(x, 0, z);
                _lostPosition = tilesOnScene.LastOrDefault().transform.position;                
            }
    }

    public void BuildRoad(int count)
    {
        if (_direction)
            CalcPositionZ(count);
        if(!_direction)
            CalcPositionX(count);
        _direction = !_direction;
    }

    private void CalcPositionX (int count)
    {
        var rndCoint = Random.Range(1, count);
        for (int i = 1; i <= count; i++)
        {
            _lostPosition.x++;
            tilesOnScene.Add(Build());
            tilesOnScene.LastOrDefault().transform.position = _lostPosition;
            if (i == rndCoint)
                poolCoin.GetTile();
        }
    }

    private void CalcPositionZ(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            _lostPosition.z++;
            tilesOnScene.Add(Build());
            tilesOnScene.LastOrDefault().transform.position = _lostPosition;
        }
    }
    public void RemoveAtToList (int i)
    {
        tilesOnScene.RemoveAt(i);
    }
}
