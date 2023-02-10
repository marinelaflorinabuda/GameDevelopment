using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyLibraryReference;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), 5, 10);
    }

    private void SpawnEnemies()
    {
        var randomNumber = Random.Range(2, 10);
        for(int i = 0; i<randomNumber;i++)
        {
            Instantiate(_enemyLibraryReference,transform);
        }
    }

}
