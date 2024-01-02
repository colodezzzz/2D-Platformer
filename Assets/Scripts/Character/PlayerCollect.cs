using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(PlayerHealth))]
public class PlayerCollect : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Item>(out Item item))
        {
            item.Collect();

            if (collision.gameObject.TryGetComponent<Heal>(out Heal heal))
            {
                _playerHealth.Heal();
            }
        }
    }
}
