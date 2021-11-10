using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Public and private variables
    public float speed = 5.0f;

    private Rigidbody2D playerRb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    
    // Moves the player using FixedUpdate rather than Update
    private void FixedUpdate()
    {
        MovePlayer();
    }

    
    // Moves the player based off of arrow key input
    void MovePlayer()
    {
        
        // MovePlayer variables
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float angleRadians = Mathf.Atan2(verticalInput, horizontalInput);
        float offsetAngle = 90;
        
        
        // Moves the player using its Rigidbody based off of arrow key input
        playerRb.AddForce(Vector2.right * speed * horizontalInput);
        playerRb.AddForce(Vector2.up * speed * verticalInput);

        // Rotates player to be faced upward if not in motion
        if (verticalInput == 0 && horizontalInput == 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        
        // Rotates player the angle it is faced while in motion using tangents
        else
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * angleRadians - offsetAngle);   
        } 
        
    }

    
    // Handles player collisions. 
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with an object, the object is destroyed.
        if (other.gameObject.CompareTag("Object"))
        {
            Destroy(other.gameObject);
        }
        
        // If the player collides with an enemy, the player is destroyed.
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
