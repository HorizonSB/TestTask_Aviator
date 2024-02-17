using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;
    private int bestScore;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverPanel;
    private bool isGamePlaying = false;

    public Action onGameEnded;

    private int maxHealthPoint = 12;
    private int currentHealthPoint;

    private int playAgain; // 1 - true, 0 - false

    [SerializeField] private GameObject[] healthPointVisuals;

    public static GameHandler Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadData();
        gameOverPanel.SetActive(false);
        currentHealthPoint = maxHealthPoint;

        if (PlayerPrefs.HasKey("PlayAgain")) playAgain = PlayerPrefs.GetInt("PlayAgain");

        if(playAgain == 1)
        {
            StartGame();
            playAgain = 0;
            PlayerPrefs.SetInt("PlayAgain", playAgain);
        }
    }

    public void StartGame()
    {
        isGamePlaying = true;
        mainMenu.SetActive(false);
        UpgradeScoreVisual();
    }

    public bool IsGamePlaying()
    {
        return isGamePlaying;
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        playAgain = 1;
        PlayerPrefs.SetInt("PlayAgain", playAgain);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScorePoint()
    {
        score += 10;
        UpgradeScoreVisual();
    }

    public void AddHealthPoint(int value)
    {
        currentHealthPoint += value;

        if(currentHealthPoint > maxHealthPoint)
        {
            currentHealthPoint = maxHealthPoint;
        }
        UprgadeHealthVisual();
    }

    public void MinusHealthPoint(int value)
    {
        currentHealthPoint -= value;
        UprgadeHealthVisual();

        if(currentHealthPoint <= 0)
        {
            onGameEnded?.Invoke();
            gameOverPanel.SetActive(true);
            isGamePlaying = false;
        }
    }


    private void LoadData()
    {
        if (PlayerPrefs.HasKey("BestScore")) bestScore = PlayerPrefs.GetInt("BestScore");
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    public int GetScore()
    {
        return score;
    }

    private void UprgadeHealthVisual()
    {
        for(int i =0; i < healthPointVisuals.Length; i++)
        {
            healthPointVisuals[i].SetActive(false);
        }

        for (int i = 0; i < currentHealthPoint; i++)
        {
            healthPointVisuals[i].SetActive(true);
        }
    }

    private void UpgradeScoreVisual()
    {
        scoreText.text = score.ToString();
    }
}
