using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    
    // Variables
    [SerializeField] private GameObject[] smorePiece;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject[] enemies;
    
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ParticleSystem scoreGlow;
    
    [SerializeField] private int collectedSmorePiece = 0;

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
        // Spawns enemies after a certain amount of time
        InvokeRepeating("SpawnRandomEnemies", startDelay, enemySpawnTime);

        // Communicates with UIManager Script
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }


    // Spawns all 4 different smore pieces in a random position
    public void SpawnSmorePieces()
    {
        for (int i = 0; i < 4; i++)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            float randomY = Random.Range(-ySpawnRange, ySpawnRange);

            Vector2 spawnPos = new Vector2(randomX, randomY);

            Instantiate(smorePiece[i], spawnPos, smorePiece[i].transform.rotation);
        }
    }

    
    // Once all 4 smore pieces are picked up, 4 new pieces are spawned, the smore piece count returns to 0, the smore score is updated, and a particle effect is played
    public void PickUpSmorePiece()
    {
        collectedSmorePiece++;
        if (collectedSmorePiece == 4)
        {
            SpawnSmorePieces();
            collectedSmorePiece = 0;
            uiManager.UpdateScore(1);
            scoreGlow.Play();
        }
    }
    
    
    // Spawns 8 random obstacles in a random position
    public void SpawnRandomObstacles()
    {
        for (int i = 0; i < 8; i++)
        {
            int randomIndex = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[randomIndex], GenerateSpawnPosition(),
                obstacles[randomIndex].gameObject.transform.rotation);  
        }
        
    }


    // Spawns a certain amount of enemies in a random direction if the game is active
    void SpawnRandomEnemies()
    {
        if (uiManager.isGameActive)
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
