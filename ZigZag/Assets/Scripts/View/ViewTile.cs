using UnityEngine;

public class ViewTile : MonoBehaviour
{
    public void Generate ()
    {
        for (int x = -1; x <= 1; x++)
            for (int z = -1; z <= 1; z++)
            {
                var tile = Instantiate(gameObject, new Vector3(x, 0, z), Quaternion.identity);     
            }
    }
}
