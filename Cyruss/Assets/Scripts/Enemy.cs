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
        Radius += 150;//Random.Range(100, 150);
    }
}
