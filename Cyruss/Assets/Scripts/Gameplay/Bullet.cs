using UnityEngine;

/// <summary>
/// Component moves itself in scene, calls the enemy destroyment and removes itself from the scene after some seconds.
/// </summary>

public class Bullet : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float movementSpeed = 5;
    [SerializeField]
    private float timeToBeDestroyed = 20;

    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        Invoke(nameof(DestroyItself), timeToBeDestroyed);
    }

    private void DestroyItself()
    {
        DestroyImmediate(gameObject);
    }

    private void Update()
    {

        _rigidBody.velocity = transform.right * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ConstsHolder.ENEMY_TAG)
        {
            var enemy = collision.GetComponent<Enemy>();
            if(enemy == null) return;

            GameEventManager.Instance.ScoreUpdated(enemy.points);
            enemy.DestroyItself();
        }
    }
}
