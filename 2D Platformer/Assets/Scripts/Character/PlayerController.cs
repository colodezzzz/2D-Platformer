using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundChecker))]
public class PlayerController : MonoBehaviour
{
    public float Direction { get; private set; }
    
    [Header("Movement settings")]
    [SerializeField] private float _movementSpeed;

    [Header("Jump settings")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private ForceMode2D _forceMode;
    [SerializeField] private float _fallRatio;

    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;
    private PlayerInput _playerInput;

    void Awake()
    {
        _playerInput = new PlayerInput();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();

        _playerInput.Player.Jump.performed += context => Jump();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        Direction = _playerInput.Player.Move.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        Move();

        if (_groundChecker.OnGround == false)
        {
            _rigidbody.velocity -= new Vector2(0f, _fallRatio);
        }
    }

    private void Jump()
    {
        if (_groundChecker.OnGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, _forceMode);
        }
    }

    private void Move()
    {
        if (_rigidbody.bodyType == RigidbodyType2D.Dynamic)
        {
            _rigidbody.velocity = new Vector2(Direction * _movementSpeed, _rigidbody.velocity.y);
        }
    }
}
