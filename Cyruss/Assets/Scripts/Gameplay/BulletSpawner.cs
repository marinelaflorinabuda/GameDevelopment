using UnityEngine;

/// <summary>
/// Component instantiates new Bullets when the onSpawnBullet event is called.
/// </summary>

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletLibraryReference;

    [SerializeField]
    private Transform startingPositionAndRotation;

    private void Start()
    {
        GameEventManager.Instance.onSpawnBullet += SpawnBullet;
    }

    private void OnDestroy()
    {
        GameEventManager.Instance.onSpawnBullet -= SpawnBullet;
    }

    private void SpawnBullet()
    {
        Instantiate(bulletLibraryReference, startingPositionAndRotation.position, startingPositionAndRotation.rotation,transform);
    }
}
