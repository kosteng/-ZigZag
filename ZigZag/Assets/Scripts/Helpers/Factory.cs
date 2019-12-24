using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private ViewTile _tile;
    [SerializeField] private ViewTile _coin;

    public ViewTile CreateTile()
    {
        var tile = Instantiate(_tile, new Vector3(0, 10, 0), Quaternion.identity);
        SetParent(tile);
        return tile;  
    }

    public ViewTile CreateCoin()
    {
        var coin = Instantiate(_coin, new Vector3(0, 10, 0), Quaternion.identity);
        SetParent(coin);
        return coin;
    }

    private void SetParent(ViewTile child)
    {
        if (_parent == null)
          _parent = GameObject.FindGameObjectWithTag("Parent");
        child.transform.SetParent(_parent.transform);
    }
}
