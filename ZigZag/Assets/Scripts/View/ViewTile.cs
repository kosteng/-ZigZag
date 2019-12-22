using UnityEngine;

public class ViewTile : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    public bool use = false;
    public void Start()
    {
        _parent = GameObject.FindGameObjectWithTag("Parent");
        transform.SetParent(_parent.transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            use = !use;
        }
    }
 
}
