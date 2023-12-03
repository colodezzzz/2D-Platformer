using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collider;

    private string _collectAnimationName;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();

        _collider.isTrigger = true;

        _collectAnimationName = "Collect";
    }

    public void Collect()
    {
        _animator.Play(_collectAnimationName);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
