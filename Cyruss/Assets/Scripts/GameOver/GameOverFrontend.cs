using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Component displays score when the game is over and takes care of the navigation to Start Scene.
/// </summary>

public class GameOverFrontend : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Button playAgain;

    private void Start()
    {
        var score = PlayerPrefs.GetString(ConstsHolder.SCORE_PLAYERPREFS_TAG, "0");
        scoreText.text = score;
        playAgain.onClick.AddListener(GoToStartScene);
    }

    private void OnDestroy()
    {
        playAgain.onClick.RemoveListener(GoToStartScene);
    }

    private void GoToStartScene()
    {
        SceneManager.LoadScene(ConstsHolder.START_SCENE_NAME);
    }
}
