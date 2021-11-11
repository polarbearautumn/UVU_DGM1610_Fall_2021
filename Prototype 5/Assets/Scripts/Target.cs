using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    // Public and private variables
    private Rigidbody targetRb;
    private GameManager gameManager;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    
    private float maxTorque = 10;
    
    private float xRange = 4;
    private float ySpawnPos = -2;

    public int pointValue;
    public ParticleSystem explosionParticle;

    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = gameObject.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    // Destroys GameObject with an explosion when clicked with the mouse and adds 5 points to the score while Game is active
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    // Destroys GameObject when it collides with the sensor and activates Game Over Text
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();   
        }
    }

    
    // Adds a random amount of force to a target in the upwards direction
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Adds a random amount of torque to a target in any direction
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Places a target at a random x range and specified y range when instantiated
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
