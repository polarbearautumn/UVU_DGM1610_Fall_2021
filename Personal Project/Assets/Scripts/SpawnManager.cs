using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Public and private variables
    public GameObject[] objects;
    public GameObject[] obstacles;

    private float xSpawnRange = 8.4f;
    private float ySpawnRange = 4.4f;
    private float xSpawnRangeObjectMax = 8.4f;
    private float xSpawnRangeObjectMin = 0.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
        SpawnRandomObstacles();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    // Spawns all 4 different Objects in a random position on only the right half of the screen
    void SpawnObjects()
    {
        for (int i = 0; i < 4; i++)
        {
            float randomX = Random.Range(xSpawnRangeObjectMin, xSpawnRangeObjectMax);
            float randomY = Random.Range(-ySpawnRange, ySpawnRange);

            Vector2 spawnPos = new Vector2(randomX, randomY);

            Instantiate(objects[i], spawnPos, objects[i].transform.rotation);
        }
    }
    
    
    // Spawns 5 random obstacles in a random position
    void SpawnRandomObstacles()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[randomIndex], GenerateSpawnPosition(),
                obstacles[randomIndex].gameObject.transform.rotation);  
        }
        
    }

    
    // Generates a random spawn position for the obstacles
    private Vector3 GenerateSpawnPosition()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomY = Random.Range(-ySpawnRange, ySpawnRange);

        Vector2 spawnPos = new Vector2(randomX, randomY);

        return spawnPos;
    }
}
