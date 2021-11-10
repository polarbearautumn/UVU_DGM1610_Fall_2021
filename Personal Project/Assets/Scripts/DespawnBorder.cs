using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DespawnBorder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroys any GameObject that touches the Despawn Border
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject)
        {
            Destroy(other.gameObject);
        }
    }
}
