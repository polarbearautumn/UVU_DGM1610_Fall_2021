using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Private variables
    private Vector3 startPos;
    private float repeatWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        // Defines the private variables
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Returns the background to its starting position when it has traveled a certain amount in the x direction
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
