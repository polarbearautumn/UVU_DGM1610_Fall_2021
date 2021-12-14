using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Public and private variables
    public TextMeshProUGUI piecesScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;

    public Button playAgainButton;

    public GameObject titleScreen;

    public UnityEvent OnGameStart;

    public bool isGameActive;
    
    private int piecesScore;
    private int score;
    private int timer = 150;
    

    
    // When the game is started, the title is screen is set to inactive
    public void StartGame()
    {
        UpdatePiecesScore(0);
        UpdateScore(0);

        isGameActive = true;
        OnGameStart.Invoke();

        StartCoroutine(StartTimer());
        titleScreen.gameObject.SetActive(false);
    }

    
    // Activates the Game Over screen and sets the game to be inactive
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
        
        isGameActive = false;
    }

    
    // Restarts the game by loading a new scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    // Starts a timer that counts down once the game is active. Activates Game Over when timer reaches 0
    IEnumerator StartTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);

            timerText.gameObject.SetActive(true);
            timerText.text = "Time: " + timer--;

            if (timer == -1)
            {
                GameOver();
            }
        }
    }
    
    
    // Shows the "Pieces Collected:" text along with an updatable score
    public void UpdatePiecesScore(int piecesScoreToAdd)
    {
        piecesScoreText.gameObject.SetActive(true);
        piecesScore += piecesScoreToAdd;
        piecesScoreText.text = "Pieces Collected: " + piecesScore;
    }
    
    
    // Shows the "'s Created:" text along with an updatable score
    public void UpdateScore(int scoreToAdd)
    {
        scoreText.gameObject.SetActive(true);
        score += scoreToAdd;
        scoreText.text = "'s Created: " + score;
    }
    
}
