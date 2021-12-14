using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Public and private variables
    public TextMeshProUGUI smoreText;
    public TextMeshProUGUI piecesScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    private int piecesScore;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdatePiecesScore(0);
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePiecesScore(int piecesScoreToAdd)
    {
        piecesScore += piecesScoreToAdd;
        piecesScoreText.text = "Pieces Collected: " + piecesScore;
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "'s Created: " + score;
    }

    public void CollectSmore()
    {
        smoreText.gameObject.SetActive(true);
    }
}
