using UnityEngine;

public class RoadBuilder 
{
    private int _lastPostionZ;
    private int _lastPostionX;
    private Pool _pool;
    private bool direсtion = false;
    public RoadBuilder (Pool pool)
    {
        _pool = pool;
    }

    public GameObject Build ()
    {
        
        direсtion = !direсtion;
        if (direсtion)
        {
            return _pool.GetTile();
        }
        else
        {
            return _pool.GetTile();
        }        
    }
    public void BuildStartingPlatform(int countX, int countZ)
    {
        for (int x = -countX; x <= countX; x++)
            for (int z = -countZ; z <= countZ; z++)
            {
                var coor = Build();
                coor.transform.position = new Vector3(x, 0, z);
                _lastPostionZ = z;
                _lastPostionX = 0;
                
            }
    }
    public void BuildRoad (int count, int direction)
    {
        if (direction == 0)
        for (int i = 1; i <= count; i++)
        {
            _lastPostionZ++;
            var coor = Build();
            coor.transform.position = new Vector3(_lastPostionX, 0, _lastPostionZ);
        }
        else
        {
            for (int i = 1; i <= count; i++)
            {
                _lastPostionX++;
                var coor = Build();
                coor.transform.position = new Vector3(_lastPostionX, 0, _lastPostionZ);
            }
        }
    }
    public void Coordinator ()
    {
        var coor = Build();
        coor.transform.position = Vector3.zero;
    }
}
