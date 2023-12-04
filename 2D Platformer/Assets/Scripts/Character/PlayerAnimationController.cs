using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(GroundChecker))]
[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerAnimationController : MonoBehaviour
{
    private const string IsRunningParameterName = "IsRunning";
    private const string OnGroundParameterName = "OnGround";
    private const string VelocityYParameterName = "VelocityY";

    private Animator _animator;
    private PlayerController _playerController;
    private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _groundChecker = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _animator.SetBool(IsRunningParameterName, _playerController.Direction != 0);
        _animator.SetBool(OnGroundParameterName, _groundChecker.OnGround);
        _animator.SetFloat(VelocityYParameterName, _rigidbody.velocity.y);

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
