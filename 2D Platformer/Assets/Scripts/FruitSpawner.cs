using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private Fruit[] _fruits;

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
            Instantiate(_fruits[Random.Range(0, _fruits.Length)], _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
