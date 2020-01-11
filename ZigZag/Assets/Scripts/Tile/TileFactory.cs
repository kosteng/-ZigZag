using UnityEngine;

public class TileFactory : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private TileView _tile;

    public TileView Create()
    {
        var tile = Instantiate(_tile, new Vector3(0, 10, 0), Quaternion.identity);
        SetParent(tile);
        return tile;  
    }

    private void SetParent(TileView child)
    {
        child.transform.SetParent(_parent.transform);
    }
}
