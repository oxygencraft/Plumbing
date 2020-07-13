using UnityEngine;

public class MetaballSpawner : MonoBehaviour
{
    public GameObject metaballPrefab = null;
    public Transform metaballParent = null;
    public int count = 20;

    // Start is called before the first frame update
    void Start()
    {
        if (metaballPrefab == null)
        {
            Debug.LogWarning("You did not specifiy a prefab for metaballs spawner!");
            return;
        }
        for (int i = 0; i < count; i++)
        {
            if (metaballParent != null)
            {
                Instantiate(metaballPrefab, transform.position, Quaternion.identity, metaballParent);
            }
            Instantiate(metaballPrefab, transform.position, Quaternion.identity);
        }
    }
}
