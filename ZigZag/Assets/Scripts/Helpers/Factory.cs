using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    public GameObject Create ()
    {
      return Instantiate(_prefab, Vector3.zero, Quaternion.identity);
    }
}
