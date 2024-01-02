using UnityEngine;

public class EnemyHitZone : MonoBehaviour
{
    [SerializeField] private float _pushForce;

    private EnemyHealth _health;

    private void Awake()
    {
        _health = GetComponentInParent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            _health.GetHit();

            Rigidbody2D _playerRigidbody = player.GetComponent<Rigidbody2D>();
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, 0f);
            _playerRigidbody.AddForce(Vector2.up * _pushForce);
        }
    }
}
