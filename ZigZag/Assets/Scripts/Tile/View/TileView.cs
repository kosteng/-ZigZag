using UnityEngine;

public class TileView : MonoBehaviour
{
    public bool Use = false;
	public GameObject Coin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BorderBackToPool")
            Use = !Use;
    }   
}
