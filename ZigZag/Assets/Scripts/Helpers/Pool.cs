using System.Collections.Generic;
using UnityEngine;
// можно реализовать очередью
public class Pool 
{
    public List<GameObject> pool;

    public void AddObject(GameObject _prefab)
    {
        pool.Add(_prefab);
    }

}
