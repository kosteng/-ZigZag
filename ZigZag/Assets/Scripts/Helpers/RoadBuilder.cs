using UnityEngine;

public class RoadBuilder 
{
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
    public void Coordinator ()
    {
        var coor = Build();
        coor.transform.position = Vector3.zero;
    }
}
