using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5;

    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidBody.velocity = transform.right * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if(collision.tag == "Enemy")
        {
            var enemy = collision.GetComponent<Enemy>();
            if(enemy == null) return;

            Debug.Log("enemy.points = " + enemy.points);
            ScoreEventSystem.Instance.ScoreUpdated(enemy.points);
            enemy.Die();
        }

    }
}
