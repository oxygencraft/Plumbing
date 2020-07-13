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
            GameObject metaball;
            if (metaballParent != null)
            {
                metaball = Instantiate(metaballPrefab, transform.position, Quaternion.identity, metaballParent);
                metaball.transform.SetParent(metaballParent);
                //metaball.hideFlags = HideFlags.HideInHierarchy;
            }
            metaball = Instantiate(metaballPrefab, transform.position, Quaternion.identity);
            //metaball.hideFlags = HideFlags.HideInHierarchy;
        }
    }
}
