using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    public int Direction { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    private Rigidbody2D _rigidbody;
    private Vector3 _startPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        Direction = -1;
    }

    private void Update()
    {
        if (transform.position.x < _startPosition.x - _distance)
        {
            Direction = 1;
        }
        else if (transform.position.x > _startPosition.x + _distance)
        {
            Direction = -1;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(Direction * _speed, _rigidbody.velocity.y);
    }
}
