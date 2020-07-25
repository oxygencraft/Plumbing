using UnityEngine;

public class ObstacleGeneratorObject : MonoBehaviour
{
    public ChunksData chunksData;
    public ObstacleGenerator ob;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collided with: " + collision.gameObject);
        var obstacle = Instantiate(GetObstacle());
        obstacle.transform.SetParent(transform.parent, true);
        obstacle.transform.position = transform.position;
        obstacle.layer = 9;
        Destroy(gameObject);
    }

    public GameObject GetObstacle()
    {
        return chunksData.obstacles[Random.Range(0, chunksData.obstacles.Count)];
    }
}