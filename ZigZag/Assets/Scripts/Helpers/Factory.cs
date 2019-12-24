using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _parentTile;
    [SerializeField] private GameObject _parentCoin;
    private int count = 0;
    [SerializeField] private ViewTile _prefab;
    public ViewTile Create ()
    {
        count++;
        Debug.Log("Factory" + count);
        var tile = Instantiate(_prefab, new Vector3(0,10,0), Quaternion.identity);
        _parentTile = GameObject.FindGameObjectWithTag("Parent");
        tile.transform.SetParent(_parentTile.transform);
        return tile;
    }
}
