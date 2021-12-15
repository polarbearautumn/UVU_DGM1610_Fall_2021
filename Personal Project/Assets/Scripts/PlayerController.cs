using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour

{

    // Public and private variables
    public ParticleSystem collisionParticle;
    public ParticleSystem collectParticle;
    public GameObject deathParticle;
    
    public UnityEvent onPlayerCollectSmore;
    public UIManager uiManager;
    
    public float speed = 5.0f;
    
    private Rigidbody2D playerRb;

    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        
        // Communicates with UIManager Script
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    
    // Moves the player using FixedUpdate rather than Update while the game is active
    private void FixedUpdate()
    {
        if (uiManager.isGameActive)
        {
            MovePlayer();
        }
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
        
        // Rotates player to the angle it is faced while in motion using tangents
        else
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * angleRadians - offsetAngle);   
        } 
        
    }

    
    // Handles player collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with a smore piece, the smore piece is destroyed. A particle effect is played, a Unity Event is invoked, and it updates the pieces collected score
        if (other.gameObject.CompareTag("SmorePiece"))
        {
            collectParticle.Play();
            Destroy(other.gameObject);
            onPlayerCollectSmore.Invoke();
            uiManager.UpdatePiecesScore(1);
        }
        
        // If the player collides with an enemy, the player is destroyed. A particle effect is played and the Game Over function is activated
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            uiManager.GameOver();
        }
    }

    
    // Handles player collision with obstacles
    private void OnCollisionEnter2D(Collision2D other)
    {
        // If the player collides with an obstacle, a collision particle effect is played
        if (other.gameObject.CompareTag("Obstacle"))
        {
            collisionParticle.Play();
        }
    }
}
