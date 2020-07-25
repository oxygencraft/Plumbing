using System.Collections;
using UnityEngine;

public class WaterDropper : MonoBehaviour
{
    public GameObject metaballPrefab;
    public int chance = 65;
    public float considerEverySeconds = 40f;
    public float delayBetweenSpawn = 0.15f;
    public float size = 1f;

    private bool firstTime = true;

    void Start()
    {
        StartCoroutine(SpawnWaterLoop());
    }

    IEnumerator SpawnWaterLoop()
    {
        for (;;)
        {
            //Debug.Log("Spawn considered!", this);
            int r = Random.Range(0, 101);
            if (r <= chance && !firstTime)
            {
                StartCoroutine(SpawnWater(Random.Range(5, 18)));
            }
            //Debug.Log("First time: " + firstTime);
            firstTime = false;
            yield return new WaitForSeconds(considerEverySeconds);
        }
    }

    IEnumerator SpawnWater(int count)
    {
        //Debug.Log("Spawning!", this);
        for (int i = 0; i < count; i++)
        {
            GameObject metaball;
            metaball = Instantiate(metaballPrefab, transform.position, Quaternion.identity);
            //metaball.hideFlags = HideFlags.HideInHierarchy;
            Vector3 scale = metaball.transform.localScale;
            scale.x = size;
            scale.y = size;
            metaball.transform.localScale = scale;
            yield return new WaitForSeconds(delayBetweenSpawn);
        }
    }
}
