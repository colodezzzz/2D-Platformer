using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider2D))]
public class Fruit : MonoBehaviour
{
    private const string CollectAnimationName = "Collect";

    private Animator _animator;
    private Collider2D _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();

        _collider.isTrigger = true;
    }

    public void Collect()
    {
        _animator.Play(CollectAnimationName);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
