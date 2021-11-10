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

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
        SpawnRandomObtacles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnObjects()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(objects[i], GenerateSpawnPosition(), objects[i].transform.rotation);
        }
    }

    void SpawnRandomObtacles()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[randomIndex], GenerateSpawnPosition(),
                obstacles[randomIndex].gameObject.transform.rotation);  
        }
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomY = Random.Range(-ySpawnRange, ySpawnRange);

        Vector2 spawnPos = new Vector2(randomX, randomY);

        return spawnPos;
    }
}
