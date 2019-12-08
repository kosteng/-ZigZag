using UnityEngine;

public class ViewTile : MonoBehaviour
{
    public void Generate ()
    {
        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
            {
                var tile = Instantiate(gameObject, new Vector3(j, 0, i), Quaternion.identity);     
            }
    }
}
