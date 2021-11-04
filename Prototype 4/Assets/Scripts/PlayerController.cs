using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public and private variables
    public float speed = 5.0f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Connects the player's Rigidbody component to a variable so we can apply force to it
        playerRb = GetComponent<Rigidbody>();
        // Connects the Focal Point GameObject to a variable so we can move based off of its position
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player forward based off the direction the focal point is facing using its Rigidbody component when up or down is pressed
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        // Sets the powerupIndicator to be at our players position
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    // If the player collides with the powerup, the hasPowerup boolean will be true and the countdown will start
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    // Makes the powerup last a certain amount of seconds
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    

    // Gives us a message if the player collided with an enemy and it has a powerup, and bounces the enemy away when the player has a powerup
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided with:" + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
