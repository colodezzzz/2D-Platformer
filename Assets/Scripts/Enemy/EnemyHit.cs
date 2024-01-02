using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.GetHit(_damage);
        }
    }
}
