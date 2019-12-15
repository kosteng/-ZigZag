using UnityEngine;

public class ViewTile : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    public void Start()
    {
        _parent = GameObject.FindGameObjectWithTag("Parent");
        transform.SetParent(_parent.transform);
    }
}
