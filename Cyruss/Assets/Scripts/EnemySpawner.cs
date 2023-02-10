using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyLibraryReference;

    private void Start()
    {
        InvokeRepeating(nameof(InstantiateEnemiesRepeating), 5, 15);
    }

    private void InstantiateEnemiesRepeating()
    {
        StartCoroutine(nameof(SpawnEnemies));
    }

    private IEnumerator SpawnEnemies()
    {
        var randomNumber = Random.Range(2, 10);
        for(int i = 0; i<randomNumber;i++)
        {
            yield return new WaitForSeconds(1);
            InstantiateEnemy();
        }
    }

    private void InstantiateEnemy()
    {
        Instantiate(_enemyLibraryReference, transform);
    }
}
