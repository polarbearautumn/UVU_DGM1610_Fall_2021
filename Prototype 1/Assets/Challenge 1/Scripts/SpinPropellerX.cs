using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    // Private Variable
    private float turnSpeed = 700.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates propeller along the Z axis
        transform.Rotate(Vector3.forward * Time.deltaTime * turnSpeed);
    }
}
