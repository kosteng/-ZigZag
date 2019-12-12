using System.Collections.Generic;
using UnityEngine;
// можно реализовать очередью
public class Pool 
{
    public List<GameObject> pool = new List<GameObject>();

    public void AddObject(GameObject _prefab)
    {
        pool.Add(_prefab);
    }

}
