using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(GroundChecker))]
[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;
    private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody;

    private string _isRunningParameterName;
    private string _onGroundParameterName;
    private string _velocityYParameterName;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _groundChecker = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _isRunningParameterName = "IsRunning";
        _onGroundParameterName = "OnGround";
        _velocityYParameterName = "VelocityY";
    }

    void Update()
    {
        _animator.SetBool(_isRunningParameterName, _playerController.Direction != 0);
        _animator.SetBool(_onGroundParameterName, _groundChecker.OnGround);
        _animator.SetFloat(_velocityYParameterName, _rigidbody.velocity.y);

        Rotate();
    }

    private void Rotate()
    {
        if (_playerController.Direction != 0)
        {
            int direction = _playerController.Direction < 0 ? -1 : 1;
            float angle = 90 - 90 * direction;
            transform.localEulerAngles = new Vector3(0f, angle, 0f);
        }        
    }
}
