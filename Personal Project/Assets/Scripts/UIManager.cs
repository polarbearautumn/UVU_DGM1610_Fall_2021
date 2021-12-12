using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Public and private variables
    public TextMeshProUGUI smoreText;
    public TextMeshProUGUI scoreText;

    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "'s Collected: " + score;
    }

    public void CollectSmore()
    {
        smoreText.gameObject.SetActive(true);
    }
}
