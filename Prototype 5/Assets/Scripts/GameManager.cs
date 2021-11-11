using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Public and private variables
    public List<GameObject> targets;
    
    private float spawnRate = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns a random target after a specified amount of seconds when condition is true
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
