using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private void Start()
    {
        var score = PlayerPrefs.GetString("Score", "0");
        text.text = score;
    }
}
