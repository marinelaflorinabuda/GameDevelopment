using System.Collections;
using UnityEngine;

/// <summary>
/// Component instantiates enemies recursively taking in consideration the dificulty chosen by the user.
/// </summary>

public class EnemySpawner : MonoBehaviour
{
    [Header("Refereneces")]
    [SerializeField]
    private GameObject _enemyLibraryReference;

    [Header("Settings")]

    [SerializeField]
    private Vector3 startingSpawnTime = new Vector3(5, 3, 1);

    [SerializeField]
    private Vector3 repeatSpawnRate = new Vector3(15, 10, 5);

    [SerializeField]
    private Vector2 minMaxBatchValues = new Vector2(2, 10);

    [SerializeField]
    private float delaySameBatchSoawn = 1;

    private void Start()
    {
        var startingTime = startingSpawnTime.x;
        var repeatRate = repeatSpawnRate.x;

        var dificulty = PlayerPrefs.GetFloat(ConstsHolder.DIFICULTY_PLAYERPREFS_TAG, 0);
        if (dificulty >= ConstsHolder.MEDIUM_DIFICULTY_VALUE - ConstsHolder.MEDIUM_DIFICULTY_OFFSET
            && dificulty <= ConstsHolder.MEDIUM_DIFICULTY_VALUE + ConstsHolder.MEDIUM_DIFICULTY_OFFSET)
        {
            startingTime = startingSpawnTime.y;
            repeatRate = repeatSpawnRate.y;
        }

        if (dificulty > ConstsHolder.MEDIUM_DIFICULTY_VALUE + ConstsHolder.MEDIUM_DIFICULTY_OFFSET)
        {
            startingTime = startingSpawnTime.z;
            repeatRate = repeatSpawnRate.z;
        }

        InvokeRepeating(nameof(InstantiateEnemiesRepeating), startingTime, repeatRate);
    }


    private void InstantiateEnemiesRepeating()
    {
        StartCoroutine(nameof(SpawnEnemies));
    }

    private IEnumerator SpawnEnemies()
    {
        var randomNumber = Random.Range(minMaxBatchValues.x, minMaxBatchValues.y);
        for (int i = 0; i < randomNumber; i++)
        {
            yield return new WaitForSeconds(delaySameBatchSoawn);
            InstantiateEnemy();
        }
    }

    private void InstantiateEnemy()
    {
        Instantiate(_enemyLibraryReference, transform);
    }
}