using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadBuilder 
{
    private Vector3 _lostPosition;
    private Pool _pool;
    private bool direсtion = false;
    public List<GameObject> tilesOnScene;

    public RoadBuilder (Pool pool)
    {
        tilesOnScene = new List<GameObject>();
        _pool = pool;
    }

    public GameObject Build ()
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

    public void BuildRoad (int count, int direction)
    {
        if (direction == 0)
        for (int i = 1; i <= count; i++)
        {
            _lostPosition.z++;
            tilesOnScene.Add(Build());
            tilesOnScene.LastOrDefault().transform.position = _lostPosition;
        }
        else
        {
            for (int i = 1; i <= count; i++)
            {
                _lostPosition.x++;
                tilesOnScene.Add(Build());
                tilesOnScene.LastOrDefault().transform.position = _lostPosition;
            }
        }
    }
}
