using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private float currentScore = 0;

    private void Start()
    {
        ScoreEventSystem.Instance.onScoreUpdated += ScoreUpdated;
        ScoreEventSystem.Instance.onGameOver += GameOver;
    }

    private void ScoreUpdated(float score)
    {
        Debug.Log("score = " + score);
        Debug.Log("currentScore = "+ currentScore);
        currentScore += score;
        Debug.Log("currentScore = "+ currentScore);
        text.text = currentScore.ToString();
    }

    private void GameOver()
    {

        SceneManager.LoadScene("GameOver");

        PlayerPrefs.SetString("Score", currentScore.ToString());
    }

}
