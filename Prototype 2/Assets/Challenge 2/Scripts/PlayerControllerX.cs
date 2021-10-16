using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canSpawnDog = true;

    private float dogSpawnDelay = 1.5f;
    
    // Update is called once per frame
    void Update()
    {
        // On space bar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canSpawnDog)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                canSpawnDog = false;
                Invoke(nameof(ResetSpawnDog), dogSpawnDelay);
            }
        }
    }

    void ResetSpawnDog()
    {
        canSpawnDog = true;
    }
}
