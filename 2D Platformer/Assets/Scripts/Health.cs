using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Health : MonoBehaviour
{
    private const string HitAnimationName = "Hit";
    private const string DieAnimationName = "Die";
    private const int BaseHitDamage = 1;

    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    public void GetHit(int damage = BaseHitDamage)
    {
        _animator.Play(HitAnimationName);
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Stop();
            _animator.Play(DieAnimationName);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void Stop()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _collider.enabled = false;
    }
}
