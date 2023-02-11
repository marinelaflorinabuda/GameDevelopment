using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Component saves the dificulty in PlayerPrefs and Starts the game by button click.
/// </summary>

public class StartFrontend : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Slider dificultySlider;

    [Header("Animations References")]
    [SerializeField]
    private Animation lowDificulty;
    [SerializeField]
    private Animation mediumDificulty;
    [SerializeField]
    private Animation highDificulty;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        dificultySlider.onValueChanged.AddListener(DificultyChanged);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartGame);
        dificultySlider.onValueChanged.RemoveListener(DificultyChanged);
    }

    private void DificultyChanged(float value)
    {
        if (value == ConstsHolder.LOW_DIFICULTY_VALUE)
            lowDificulty.Play();

        if (value >= ConstsHolder.MEDIUM_DIFICULTY_VALUE - ConstsHolder.MEDIUM_DIFICULTY_OFFSET &&
            value <= ConstsHolder.MEDIUM_DIFICULTY_VALUE + ConstsHolder.MEDIUM_DIFICULTY_OFFSET)
            mediumDificulty.Play();

        if (value == ConstsHolder.HIGH_DIFICULTY_VALUE)
            highDificulty.Play();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(ConstsHolder.GAMEPLAY_SCENE_NAME);
        PlayerPrefs.SetFloat(ConstsHolder.DIFICULTY_PLAYERPREFS_TAG, dificultySlider.value);
    }
}
