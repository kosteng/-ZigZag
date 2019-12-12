using UnityEngine;

public class ViewTile : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    public void Start()
    {
        _parent = GameObject.FindGameObjectWithTag("Parent");
        Debug.Log(_parent);

    }
    public void Generate ()
    {
        for (int x = -5; x <= 5; x++)
            for (int z = -10; z <= 10; z++)
            {
                var tile = Instantiate(gameObject, new Vector3(x, 0, z), Quaternion.identity);
                tile.transform.SetParent(_parent.transform);
            }
    }
}
