using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField]
    private float RotateSpeed = 5f;
    [SerializeField]
    private float Radius = 10f;
    private Vector3 _startingPosition;
    private float _angle;
    public float points = 15;

    private void Start()
    {
        _startingPosition = transform.position;
        InvokeRepeating(nameof(IncreaseRadius), 1, 5);
    }

    private void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle),0) * Radius;
        transform.position = _startingPosition + offset;
    }

    private void IncreaseRadius()
    {
        Radius += 150;
        points -= 5;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreEventSystem.Instance.GameOver();
        }
    }

}
