using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    public int Direction { get; private set; }

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    private Rigidbody2D _rigidbody;
    private Vector3 _leftPointPosition;
    private Vector3 _rightPointPosition;
    private Transform _player;
    private float _currentSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _leftPointPosition = _leftPoint.position;
        _rightPointPosition = _rightPoint.position;
        _currentSpeed = _walkSpeed;

        Direction = -1;
    }

    private void Update()
    {
        SetDirection();
    }

    private void FixedUpdate()
    {
        if (_rigidbody.bodyType == RigidbodyType2D.Dynamic)
        {
            _rigidbody.velocity = new Vector2(Direction * _currentSpeed, _rigidbody.velocity.y);
        }
    }

    public void SetTarget(Transform target)
    {
        _player = target;
        _currentSpeed = _runSpeed;
    }

    public void UnsetTarget()
    {
        _player = null;
        _currentSpeed = _walkSpeed;
    }

    private void SetDirection()
    {
        if (_player == null)
        {
            if (transform.position.x < _leftPointPosition.x)
            {
                Direction = 1;
            }
            else if (transform.position.x > _rightPointPosition.x)
            {
                Direction = -1;
            }
        }
        else
        {
            if (transform.position.x < _player.position.x)
            {
                Direction = 1;
            }
            else if (transform.position.x > _player.position.x)
            {
                Direction = -1;
            }
        }
    }
}
