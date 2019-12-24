using UnityEngine;

public class ViewTile : MonoBehaviour
{
    public bool use = false;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            use = !use;
        }
    }
}
