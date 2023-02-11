using System;

/// <summary>
/// Holder for events during Gameplay.
/// </summary>

public class GameEventManager : BasicEventManager<GameEventManager> 
{
    public Action<float> onScoreUpdated;
    public Action onGameOver;
    public Action onSpawnBullet;

    public void ScoreUpdated(float score)
    {
        onScoreUpdated?.Invoke(score);
    }

    public void GameOver()
    {
        onGameOver?.Invoke();
    }

    public void SpawnBullet()
    {
        onSpawnBullet?.Invoke();
    }
}
