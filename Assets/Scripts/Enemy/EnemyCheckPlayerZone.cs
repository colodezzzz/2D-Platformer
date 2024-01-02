using UnityEngine;

public class EnemyCheckPlayerZone : MonoBehaviour
{
    private const string IsAngryParameterName = "IsAngry";

    private Animator _animator;
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            _animator.SetBool(IsAngryParameterName, true);
            _enemyMovement.SetTarget(player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            _animator.SetBool(IsAngryParameterName, false);
            _enemyMovement.UnsetTarget();
        }
    }
}
