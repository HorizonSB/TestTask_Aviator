using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject newRecordPanel;
    [SerializeField] private GameObject newRecordTitle;
    [SerializeField] private GameObject planeCrashed;


    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        int score = GameHandler.Instance.GetScore();
        int bestScore = GameHandler.Instance.GetBestScore();

        if (score > bestScore)
        {
            planeCrashed.SetActive(false);
            newRecordPanel.SetActive(true);
            newRecordTitle.SetActive(true);

            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();

    }
}
