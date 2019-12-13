using UnityEngine;

public class RoadBuilder 
{
    private Pool _pool;
    private bool direсtion = false;
    public RoadBuilder (Pool pool)
    {
        _pool = pool;
    }

    public GameObject BuildRoader ()
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
}
