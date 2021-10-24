using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Private and public variables
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        // Communicates with the PlayerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        // Spawns multiple objects over a period of time
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // Spawns a new obstacle if the player has not collided with an obstacle
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
