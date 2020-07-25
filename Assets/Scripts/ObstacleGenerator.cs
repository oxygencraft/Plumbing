using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public ChunksData chunksData;

    void Start()
    {
        int obstacles = Random.Range(0, 4);
        for (int i = 0; i < obstacles; i++)
        {
            GenerateObstacle();
        }
        Destroy(gameObject);
    }

    void GenerateObstacle()
    {
        float x = transform.parent.position.x;
        var objectPosition = new Vector2(Random.Range(x - 5f, x + 5f), 5f);
        var obstacleGen = new GameObject("Obstacle Generator Object");
        obstacleGen.transform.position = objectPosition;
        obstacleGen.transform.SetParent(transform.parent);
        obstacleGen.layer = 10;
        obstacleGen.AddComponent<CircleCollider2D>();
        var rb = obstacleGen.AddComponent<Rigidbody2D>();
        var script = obstacleGen.AddComponent<ObstacleGeneratorObject>();
        script.chunksData = chunksData;
        script.ob = this;
        rb.gravityScale = 10;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}