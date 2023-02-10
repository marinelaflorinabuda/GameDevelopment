using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEventSystem : BasicEventManager<ScoreEventSystem>
{
    public Action<float> onScoreUpdated;
    public Action onGameOver;

    public void ScoreUpdated(float score)
    {
        onScoreUpdated?.Invoke(score);
    }

    public void GameOver()
    {
        onGameOver.Invoke();
    }
}
