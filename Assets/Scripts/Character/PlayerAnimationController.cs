using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(GroundChecker))]
[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerAnimationController : MonoBehaviour
{
    private const string IsRunningParameterName = "IsRunning";
    private const string OnGroundParameterName = "OnGround";
    private const string VelocityYParameterName = "VelocityY";
    private const string IsInvulnerableParameterName = "IsInvulnerable";
    private const string HitParameterName = "Hit";

    private const string DieAnimationName = "Die";

    private Animator _animator;
    private PlayerController _playerController;
    private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _groundChecker = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        _animator.SetBool(IsRunningParameterName, _playerController.Direction != 0);
        _animator.SetBool(OnGroundParameterName, _groundChecker.OnGround);
        _animator.SetFloat(VelocityYParameterName, _rigidbody.velocity.y);

        Rotate();
    }

    public void PlayHitAnimation()
    {
        _animator.SetTrigger(HitParameterName);
    }

    public void PlayDieAnimation()
    {
        Stop();
        _animator.Play(DieAnimationName);
    }

    private void SetIsInvulnerableParameterToFalse()
    {
        _animator.SetBool(IsInvulnerableParameterName, false);
    }

    private void SetIsInvulnerableParameterToTrue()
    {
        _animator.SetBool(IsInvulnerableParameterName, true);
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

    private void Stop()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _collider.enabled = false;
    }
}
