using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerate: MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform player;

    [Header("Spawning")]
    [SerializeField] float chunkHeight = 12f;
    [SerializeField] float spawnAheadDistance = 24f;
    [SerializeField] float despawnDistance = 12f;

    [SerializeField] GameObject[] chunkPrefab;    

    [Header ("Starting Chunks")]
    [Tooltip("Pre-placed chunks at the level start; despawned like any other chunk.")]
    [SerializeField] GameObject startingChunk;
    [Tooltip("Offset so the first spawned chunk doesn't overlap the starting chunks.")]
    [SerializeField] float firstChunkOffset = 12f;

    readonly List<GameObject> spawnedChunks = new List<GameObject>();

    float nextSpawnY;
   
    private void Start()
    {
        nextSpawnY = transform.position.y + firstChunkOffset;
    }

    void Update()
    {
        if(nextSpawnY - player.position.y < spawnAheadDistance)
        {
            SpawnChunk();
        }
        DespawnChunksBelowPlayer();
    }

    void SpawnChunk()
    {
        GameObject  prefab = chunkPrefab[Random.Range(0, chunkPrefab.Length)];
        GameObject chunk = Instantiate(prefab, new Vector3(0f, nextSpawnY, 0f), Quaternion.identity);
        spawnedChunks.Add(chunk);
        nextSpawnY += chunkHeight;
    }

    void DespawnChunksBelowPlayer()
    {
        for(int i = spawnedChunks.Count -1; i >= 0; i--)
        {
            GameObject chunk = spawnedChunks[i];
            if(player.position.y - chunk.transform.position.y > despawnDistance)
            {
                spawnedChunks.RemoveAt(i);
                Destroy(chunk);
            }
        }
    }
}
