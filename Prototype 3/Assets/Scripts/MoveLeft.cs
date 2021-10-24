using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Private variables
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    
    // Start is called before the first frame update
    void Start()
    {
        // Communicates with the PlayerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moves obstacles to the left if the player has not collided with them
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Destroys obstacles that go off screen
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
