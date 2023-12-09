using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnManager : MonoBehaviour
{
    public GameObject[] leftPlatforms;
    public GameObject[] rightPlatforms;
    public Transform player;
    public float spawnHeight = 2f;
    public float offScreenY = -30f;

    public GameObject starPrefab;
    private int platformCount = 0;

    private Vector3 nextSpawnPoint;

    void Start()
{
    // Initialize the next spawn point
    nextSpawnPoint = transform.position;

    // Spawn initial platforms
    for (int i = 0; i < 20; i++)
    {
        SpawnPlatform();
        nextSpawnPoint += new Vector3(0, spawnHeight, 0);
    }
}

    void Update()
    {
        // Delete platforms that are off screen
        foreach (Transform child in transform)
        {
            if (child.position.y < player.position.y + offScreenY)
            {
                Destroy(child.gameObject);
                SpawnPlatform();
                nextSpawnPoint += new Vector3(0, spawnHeight, 0);
            }
        }
    }

    private int platformIndex = 0;

    void SpawnPlatform()
    {
        // Select a random platform prefab
        GameObject platform = platformIndex % 2 == 0 ? 
        leftPlatforms[Random.Range(0, leftPlatforms.Length)] : 
        rightPlatforms[Random.Range(0, rightPlatforms.Length)];

        platformCount++;

        if (platformCount % 5 == 0)
        {
            // Instantiate the star prefab at the platform position
            Instantiate(starPrefab, nextSpawnPoint + new Vector3(0, 1, 0), Quaternion.identity);
        }

        // Instantiate the platform at the next spawn point
        Instantiate(platform, nextSpawnPoint, Quaternion.identity, transform);

        // Increment the platform index
        platformIndex++;
    }
}