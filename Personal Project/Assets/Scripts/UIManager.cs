using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Public and private variables
    public TextMeshProUGUI piecesScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public Button playAgainButton;

    public bool isGameActive;

    private int piecesScore;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdatePiecesScore(0);
        UpdateScore(0);

        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
        
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Shows the "Pieces Collected:" text along with an updatable score
    public void UpdatePiecesScore(int piecesScoreToAdd)
    {
        piecesScore += piecesScoreToAdd;
        piecesScoreText.text = "Pieces Collected: " + piecesScore;
    }
    
    // Shows the "'s Created:" text along with an updatable score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "'s Created: " + score;
    }
    
}
