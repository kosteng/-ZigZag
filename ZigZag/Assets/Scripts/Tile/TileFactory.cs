﻿using UnityEngine;

public class TileFactory : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private TileView _tilePrefab;

    public TileView Create()
    {
        var tile = Instantiate(_tilePrefab, new Vector3(0f, 10f, 0f), Quaternion.identity);
        SetParent(tile);
        return tile;  
    }

    private void SetParent(TileView child)
    {
        child.transform.SetParent(_parent.transform);
    }
}
