using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Public and private variables
    public GameObject[] objects;
    public GameObject[] obstacles;
    public GameObject[] enemies;

    private float xSpawnRange = 8.4f;
    private float ySpawnRange = 4.4f;

    private float xSpawnRangeEnemy = 10.0f;
    private float ySpawnRangeEnemy = 6.0f;

    private float startDelay = 2.0f;
    private float enemySpawnTime = 5.0f;

    private Vector2 direction;

    
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
        SpawnRandomObstacles();
        
        // Spawns enemies after a certain amount of time
        InvokeRepeating("SpawnRandomEnemies", startDelay, enemySpawnTime);
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
            float randomX = Random.Range(0, xSpawnRange);
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


    // Spawns a certain amount of enemies in a random direction 
    void SpawnRandomEnemies()
    {
        for (int i = 0; i < 2; i++)
        {
            int randomSpawnEnemyDirection = Random.Range(0, 4);

            if (randomSpawnEnemyDirection == 0)
            {
                SpawnEnemyUp();
            }
            else if (randomSpawnEnemyDirection == 1)
            {
                SpawnEnemyDown();
            }
            else if (randomSpawnEnemyDirection == 2)
            {
                SpawnEnemyRight();
            }
            else if (randomSpawnEnemyDirection == 3)
            {
                SpawnEnemyLeft();
            }
        }
    }


    // Spawns enemies in a random position at the top of the screen, rotated in the correct direction
    void SpawnEnemyUp()
    {
        float xSpawnRangeEnemyRandom = Random.Range(-xSpawnRange, xSpawnRange);

        Vector2 spawnPos = new Vector2(xSpawnRangeEnemyRandom, ySpawnRangeEnemy);
        
        int randomIndex = Random.Range(0, enemies.Length);
        
        // Change z value to 90/180/270 degrees based on where its facing
        Instantiate(enemies[randomIndex], spawnPos, Quaternion.Euler(0,0,180));
    }

    // Spawns enemies in a random position at the bottom of the screen, rotated in the correct direction
    void SpawnEnemyDown()
    {
        float xSpawnRangeEnemyRandom = Random.Range(-xSpawnRange, xSpawnRange);

        Vector2 spawnPos = new Vector2(xSpawnRangeEnemyRandom, -ySpawnRangeEnemy);
        
        int randomIndex = Random.Range(0, enemies.Length);
        
        // Change z value to 90/180/270 degrees based on where its facing
        Instantiate(enemies[randomIndex], spawnPos, Quaternion.Euler(0,0,0));
    }

    // Spawns enemies in a random position at the right of the screen, rotated in the correct direction
    void SpawnEnemyRight()
    {
        float ySpawnRangeEnemyRandom = Random.Range(-ySpawnRange, ySpawnRange);

        Vector2 spawnPos = new Vector2(xSpawnRangeEnemy, ySpawnRangeEnemyRandom);
        
        int randomIndex = Random.Range(0, enemies.Length);
        
        // Change z value to 90/180/270 degrees based on where its facing
        Instantiate(enemies[randomIndex], spawnPos, Quaternion.Euler(0,0,90));
    }

    // Spawns enemies in a random position at the left of the screen, rotated in the correct direction
    void SpawnEnemyLeft()
    {
        float ySpawnRangeEnemyRandom = Random.Range(-ySpawnRange, ySpawnRange);

        Vector2 spawnPos = new Vector2(-xSpawnRangeEnemy, ySpawnRangeEnemyRandom);
        
        int randomIndex = Random.Range(0, enemies.Length);
        
        // Change z value to 90/180/270 degrees based on where its facing
        Instantiate(enemies[randomIndex], spawnPos, Quaternion.Euler(0,0,270));
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
