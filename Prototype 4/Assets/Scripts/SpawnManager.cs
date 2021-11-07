using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Public and private variables
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    
    private float spawnRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    { 
        // Spawns enemies and powerups in a random location and a specified rotation
       SpawnEnemyWave(waveNumber);
       Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Finds how many enemies are on the screen, and when that reaches 0, it spawns an increasing amount of enemies
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    // Uses a For Loop to spawn 3 enemies
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); 
        }
    }

    // Generates a random spawn position (in this case, for an enemy)
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
