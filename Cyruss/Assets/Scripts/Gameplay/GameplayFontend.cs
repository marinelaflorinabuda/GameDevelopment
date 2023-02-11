using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Component displays the score, loads gameOver scene and takes the user back to Start scene.
/// </summary>

public class GameplayFontend : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Button backButton;

    private float _currentScore;

    private void Start()
    {
        GameEventManager.Instance.onScoreUpdated += ScoreUpdated;
        GameEventManager.Instance.onGameOver += GameOver;
        backButton.onClick.AddListener(GoBackToStartScene);
    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(GoBackToStartScene);
        GameEventManager.Instance.onScoreUpdated -= ScoreUpdated;
        GameEventManager.Instance.onGameOver -= GameOver;
    }

    private void GoBackToStartScene()
    {
        SceneManager.LoadScene(ConstsHolder.START_SCENE_NAME);
    }

    private void ScoreUpdated(float score)
    {
        _currentScore += score;
        scoreText.text = _currentScore.ToString();
    }

    private void GameOver()
    {
        SceneManager.LoadScene(ConstsHolder.GAME_OVER_SCENE_NAME);
        PlayerPrefs.SetString(ConstsHolder.SCORE_PLAYERPREFS_TAG, _currentScore.ToString());
    }
}
