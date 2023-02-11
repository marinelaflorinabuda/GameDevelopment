using UnityEngine;

/// <summary>
/// Component moves around a circle and the diameter of the movement increases slowly. When the diameter increases the points decrease.
/// When in contact with the Player it calls "GameOver".
/// </summary>

public class Enemy : MonoBehaviour
{
    public float points { get; private set; } = 15;

    [Header("Settings")]
    [SerializeField]
    private float Speed = 5f;
    [SerializeField]
    private float Radius = 10f;
    [SerializeField]
    private float startingTime = 1;
    [SerializeField]
    private float repeatRate = 5;

    private float _angle;
    private Vector3 _startingPosition;


    private void Start()
    {
        _startingPosition = transform.position;
        InvokeRepeating(nameof(IncreaseRadiusAndDecreasePoints), startingTime, repeatRate);
    }

    private void Update()
    {
        _angle += Speed * Time.deltaTime;

        var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle),0) * Radius;
        transform.position = _startingPosition + offset;
    }

    private void IncreaseRadiusAndDecreasePoints()
    {
        Radius += 150;
        points = Mathf.Clamp(points - 5, 0 , points);
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ConstsHolder.PLAYER_TAG)
            GameEventManager.Instance.GameOver();
    }
}
