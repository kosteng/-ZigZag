using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    public void Create ()
    {
       Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        Instantiate(_prefab, new Vector3 (1,0,1), Quaternion.identity);

    }
}
