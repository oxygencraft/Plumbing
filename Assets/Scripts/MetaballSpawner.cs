using System.Collections;
using UnityEngine;

public class MetaballSpawner : MonoBehaviour
{
    public GameObject metaballPrefab = null;
    private static GameObject staticMetaballPrefab;
    public int count = 20;
    public float size = 1f;
    public float delayBetweenSpawn = 0f;

    public static void SpawnMetaball(Transform transform, float size)
    {
        GameObject metaball;
        metaball = Instantiate(staticMetaballPrefab, transform.position, Quaternion.identity);
        //metaball.hideFlags = HideFlags.HideInHierarchy;
        Vector3 scale = metaball.transform.localScale;
        scale.x = size;
        scale.y = size;
        metaball.transform.localScale = scale;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (metaballPrefab == null)
        {
            Debug.LogWarning("You did not specifiy a prefab for metaballs spawner!");
            return;
        }
        staticMetaballPrefab = metaballPrefab;
        if (delayBetweenSpawn <= 0f)
        {
            for (int i = 0; i < count; i++)
            {
                SpawnMetaball(transform, size);
            }
        }
        else
        {
            StartCoroutine(SpawnMetaballsDelayed());
        }
    }

    IEnumerator SpawnMetaballsDelayed()
    {
        for (int i = 0; i < count; i++)
        {
            SpawnMetaball(transform, size);
            yield return new WaitForSeconds(delayBetweenSpawn);
        }
    }
}
