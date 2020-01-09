using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private ViewTile _tile;

    public ViewTile CreateTile()
    {
        var tile = Instantiate(_tile, new Vector3(0, 10, 0), Quaternion.identity);
        SetParent(tile);
        return tile;  
    }

    private void SetParent(ViewTile child)
    {
        child.transform.SetParent(_parent.transform);
    }
}
