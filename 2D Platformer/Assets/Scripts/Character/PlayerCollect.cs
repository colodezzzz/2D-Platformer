using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Item>(out Item item))
        {
            item.Collect();
        }
    }
}
