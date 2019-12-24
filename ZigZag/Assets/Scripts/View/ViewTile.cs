using UnityEngine;

public class ViewTile : MonoBehaviour
{
    public bool use = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BorderBackToPool")
            use = !use;
    }
    
}
