using UnityEngine;

public class TileView : MonoBehaviour
{
    public bool UseTile = false;
	public GameObject CoinOnTile;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BorderBackToPool")
            UseTile = !UseTile;
    }   
}
