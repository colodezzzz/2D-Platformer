using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
        {
            fruit.Collect();
        }
    }
}
