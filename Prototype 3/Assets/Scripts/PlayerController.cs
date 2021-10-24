using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private and public variables
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Lets us change how physics interacts with the player's rigidbody
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Instantly moves the player up when space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Tells us "Game Over" when the player has collided with an obstacle
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
        
    }
}
