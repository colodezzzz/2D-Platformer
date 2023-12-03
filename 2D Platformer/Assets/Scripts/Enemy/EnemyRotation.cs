using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class EnemyRotation : MonoBehaviour
{
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float angle = 90 + 90 * _enemyMovement.Direction;
        transform.localEulerAngles = new Vector3(0f, angle, 0f);
    }
}
