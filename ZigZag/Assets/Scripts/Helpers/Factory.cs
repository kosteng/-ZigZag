using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    public GameObject Create ()
    {
      return Instantiate(_prefab, new Vector3(0,10,0), Quaternion.identity);
    }
}
