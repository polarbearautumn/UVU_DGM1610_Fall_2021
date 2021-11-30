using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour

{

    public UnityEvent<string> onPlayerDead;
    
    // Public and private variables
    public float speed = 5.0f;

    private Rigidbody2D playerRb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        onPlayerDead.Invoke("Hello");
        
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
            //invoke unity event here
            //add canvas and ui manager script, have function that shows pickup text
            //add that function to the list of callbacks in the unityevent
            
            //ask frez about enums
            //smorepiece script on all pieces, smoretype variable w/graham cracker, chocolate, mallow
        }
        
        // If the player collides with an enemy, the player is destroyed.
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
