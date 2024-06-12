using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int score;
    public int highestScore;
    public Text scoreText;
    public Text highestScoreText;
    public GameObject gameOverScreen;
    public GameObject gamePausedScreen;
    public AudioSource scoreIncreaseSfx;
    public BirdScript bird;

    void Start()
    {
        highestScore = PlayerPrefs.GetInt("highestScore");
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePausedScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        if (bird.birdIsAlive)
        {
            score += scoreToAdd;
            scoreText.text = score.ToString();
            scoreIncreaseSfx.Play();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("highestScore", score);
            highestScoreText.text = "Highest Score: " + highestScore.ToString();
        }
    }

    public void ContinueGame()
    {
        gamePausedScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
