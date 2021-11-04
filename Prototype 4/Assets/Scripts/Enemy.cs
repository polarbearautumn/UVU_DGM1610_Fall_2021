using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Public and private variables
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        // Connects the player's Rigidbody component to a variable so we can apply force to it
        enemyRb = GetComponent<Rigidbody>();
        // Connects the player GameObject to a variable so the enemy can move based off of its position
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}
