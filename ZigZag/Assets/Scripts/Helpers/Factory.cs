using UnityEngine;

public class Factory : MonoBehaviour
{
    private int count = 0;
    [SerializeField] private ViewTile _prefab;
    public ViewTile Create ()
    {
        count++;
        Debug.Log("Factory" + count);
        return Instantiate(_prefab, new Vector3(0,10,0), Quaternion.identity);        
    }
}
