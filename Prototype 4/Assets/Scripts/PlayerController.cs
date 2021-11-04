using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public and private variables
    public float speed = 5.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;

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
    }
}
