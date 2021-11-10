using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Public and private variables
    public float speed = 0.3f;

    private Rigidbody2D enemyRb;
    private GameObject player;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Moves the enemies using their Rigidbodies
        enemyRb.AddForce(transform.up * speed);
    }
}
