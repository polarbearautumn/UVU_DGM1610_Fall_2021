using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Public and private variables
    public float speed = 5.0f;
    
    private float yBound = 4.4f;
    private float xBound = 8.4f;
    
    private float horizontalInput;
    private float verticalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();
        ConstrainPlayerPosition();
        
    }

    
    // Moves the player based off of arrow key input
    void MovePlayer()
    {
        
        // Float variables
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float angleRadians = Mathf.Atan2(verticalInput, horizontalInput);
        float offsetAngle = 90;
        
        
        // Manually updates player position by adding the current position to the position inputted
        transform.position += new Vector3(Time.deltaTime * speed * horizontalInput,
            Time.deltaTime * speed * verticalInput);
        
        
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

    
    // Prevents the player from leaving the game scene
    void ConstrainPlayerPosition()
    {
        
        // Constrains the player within the y bounds of the game scene
        if (transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound);
        }

        if (transform.position.y < -yBound)
        {
            transform.position = new Vector3(transform.position.x, -yBound);
        }

        
        // Constrains the player within the x bounds of the game scene
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y);
        }
        
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y);
        } 
        
    }
}
