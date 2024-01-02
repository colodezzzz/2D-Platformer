using UnityEngine;

[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerHealth : MonoBehaviour
{
    private const int BaseHitDamage = 1;
    private const int BaseHealPoints = 1;

    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private bool _isInvulnerable;
    private PlayerAnimationController _playerAnimationController;

    private void Awake()
    {
        _isInvulnerable = false;
        _currentHealth = _maxHealth;
        _playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    public void Heal(int healPoints = BaseHealPoints)
    {
        _currentHealth += healPoints;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void GetHit(int damage = BaseHitDamage)
    {
        if (_isInvulnerable)
        {
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _playerAnimationController.PlayDieAnimation();
        }
        else
        {
            StartInvulnerability();
            _playerAnimationController.PlayHitAnimation();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void StartInvulnerability()
    {
        _isInvulnerable = true;
    }

    private void EndInvulnerability()
    {
        _isInvulnerable = false;
    }
}
