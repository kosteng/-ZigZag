using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadBuilder 
{
    private bool _direction = true;
    private Vector3 _lostPosition;
    public Pool _pool;
    public List<ViewTile> tilesOnScene;
    
    public RoadBuilder (Pool pool)
    {
        tilesOnScene = new List<ViewTile>();
        _pool = pool;
    }

    public ViewTile Build ()
    {
        return _pool.GetTile();
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

    public void BuildRoad (int count)
    {
        if (_direction)
        for (int i = 1; i <= count; i++)
        {
            _lostPosition.z++;
            tilesOnScene.Add(Build());
            tilesOnScene.LastOrDefault().transform.position = _lostPosition;

        }
        if(!_direction)
        {
            for (int i = 1; i <= count; i++)
            {
                _lostPosition.x++;
                tilesOnScene.Add(Build());
                tilesOnScene.LastOrDefault().transform.position = _lostPosition;
            }
        }
        _direction = !_direction;
    }

    public void RemoveAtToList (int i)
    {
        tilesOnScene.RemoveAt(i);
    }
}
