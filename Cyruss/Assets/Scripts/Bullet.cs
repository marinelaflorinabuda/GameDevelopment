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
}
