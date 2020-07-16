using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public Transform parent;
    public ChunksData chunks;

    private Vector3 nextLocation;
    private ChunkGroup currentChunkGroup;
    private ChunkGroup nextChunkGroup;
    private ChunkGroup nextNonConnectorGroup;
    private Chunk nextChunk;
    private int chunkGroupIndex;
    private bool isNextGroupConnector = false;

    void Start()
    {
        // we need to do this twice so that currentChunkGroup is not null
        GetNextChunkGroup();
        GetNextChunkGroup();
        chunkGroupIndex = 0;
        nextChunk = currentChunkGroup.chunks[0];
        var position = transform.position;
        position.x -= nextChunk.positionIncrement;
        transform.position = position;
        nextLocation = transform.position;
        for (int i = 0; i < currentChunkGroup.chunks.Count; i++)
        {
            CreateNextChunk(true);
        }
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, nextLocation) < 11)
            CreateNextChunk();
    }

    private void CreateNextChunk(bool moveObject = false)
    {
        GameObject chunk = new GameObject("Chunk " + currentChunkGroup.name);
        chunk.transform.position = nextLocation;
        var spriteRenderer = chunk.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = nextChunk.sprite;
        var selfDestruct = chunk.AddComponent<SelfDestruct>();
        selfDestruct.timeUntilSelfDestruct = nextChunk.timeUntilSelfDestruct;
        chunk.transform.SetParent(parent);
        nextLocation.x += nextChunk.positionIncrement;
        if (moveObject)
        {
            Vector3 position = transform.position;
            position.x += nextChunk.positionIncrement;
            transform.position = position;
        }

        if (currentChunkGroup.chunks.Count == ++chunkGroupIndex)
        {
            chunkGroupIndex = 0;
            GetNextChunkGroup();
            nextChunk = currentChunkGroup.chunks[0];
        }
        else
        {
            nextChunk = currentChunkGroup.chunks[chunkGroupIndex];
        }
    }

    private void GetNextChunkGroup()
    {
        currentChunkGroup = nextChunkGroup;
        if (nextNonConnectorGroup == null)
        {
            var nextGroup = chunks.chunkGroups[Random.Range(0, chunks.chunkGroups.Count)];
            nextNonConnectorGroup = nextGroup;
        }
        if (isNextGroupConnector)
        {
            var nextGroup = chunks.chunkGroups[Random.Range(0, chunks.chunkGroups.Count)];
            if (nextGroup.name == nextChunkGroup.name)
                return;
            nextNonConnectorGroup = nextGroup;
            nextChunkGroup = chunks.GetChunkConnectorGroup(nextChunkGroup, nextGroup);
        }
        else
        {
            nextChunkGroup = nextNonConnectorGroup;
        }

        isNextGroupConnector = !isNextGroupConnector;
    }
}
