using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Chunks Data", menuName = "Chunks Data")]
public class ChunksData : ScriptableObject
{
    public Material allChunkMaterial;
    public List<GameObject> obstacles;
    public List<ChunkGroup> chunkGroups;
    public List<ChunkConnectorGroup> chunkConnectorGroups;

    public ChunkGroup GetChunkConnectorGroup(ChunkGroup previousChunkGroup, ChunkGroup nextChunkGroup)
    {
        foreach (var chunkConnectorGroup in chunkConnectorGroups)
        {
            if (chunkConnectorGroup.from == previousChunkGroup.name &&
                chunkConnectorGroup.to == nextChunkGroup.name)
            {
                return chunkConnectorGroup.chunkGroup;
            }
        }

        return null;
    }

    public ChunkGroup GetChunkGroup(string name)
    {
        foreach (var chunkGroup in chunkGroups)
        {
            if (chunkGroup.name == name)
                return chunkGroup;
        }

        return null;
    }
}

[Serializable]
public class ChunkGroup
{
    public string name;
    public List<Chunk> chunks;
}

[Serializable]
public class ChunkConnectorGroup
{
    public string from;
    public string to;
    public ChunkGroup chunkGroup;
}

[Serializable]
public class Chunk
{
    //public Sprite sprite;
    public GameObject prefab;
    //public Material material;
    public float positionIncrement;
    //public float timeUntilSelfDestruct;
}
