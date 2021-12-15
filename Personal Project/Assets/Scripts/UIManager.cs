using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour

{
    
    // Variables
    [SerializeField] private TextMeshProUGUI piecesScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private Button playAgainButton;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject titleScreen;

    [SerializeField] private UnityEvent onGameStart;

    public bool isGameActive;
    
    private int piecesScore;
    private int score;
    private int timer = 150;
    

    
    // When the game is started, the scores appear, a Unity Event is invoked, the timer begins, the player appears, and the title screen disappears
    public void StartGame()
    {
        UpdatePiecesScore(0);
        UpdateScore(0);

        isGameActive = true;
        onGameStart.Invoke();

        StartCoroutine(StartTimer());
        
        playerPrefab.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    
    // Activates the Game Over screen and sets the game to inactive
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
    
    
    // Shows the "Pieces Collected:" text while the game is active, along with an updatable score
    public void UpdatePiecesScore(int piecesScoreToAdd)
    {
        piecesScoreText.gameObject.SetActive(true);
        piecesScore += piecesScoreToAdd;
        piecesScoreText.text = "Pieces Collected: " + piecesScore;
    }
    
    
    // Shows the "'s Created:" text while the game is active, along with an updatable score
    public void UpdateScore(int scoreToAdd)
    {
        scoreText.gameObject.SetActive(true);
        score += scoreToAdd;
        scoreText.text = "'s Created: " + score;
    }
    
}
