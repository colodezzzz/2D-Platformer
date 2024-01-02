using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [SerializeField] private Heal _healPrefab;

    private Transform[] _spawnPoints;

    void Awake()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }
    }

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_healPrefab, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
