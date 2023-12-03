using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool OnGround { get; private set; }

    [SerializeField] private Transform _position;
    [SerializeField] private Vector2 _size;
    [SerializeField] private float _angle;
    [SerializeField] private LayerMask _groundLayers;

    void Update()
    {
        Check();
    }

    private void Check()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(_position.position, _size, _angle, _groundLayers);
        OnGround = colliders.Length > 0;
    }
}
