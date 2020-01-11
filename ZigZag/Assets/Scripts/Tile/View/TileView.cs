using UnityEngine;

public class TileView : MonoBehaviour
{
    public bool use = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BorderBackToPool")
            use = !use;
    }   
}
