using UnityEngine;

public class Spawner : PoolOfObjects
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay;

    private float _elapsedTime = 0;

    private void Start()
    {
        foreach (var enemy in _enemyPrefabs)
        {
            Initialize(enemy);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnDelay)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
                int enemyPrefabIndex = Random.Range(0, _enemyPrefabs.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointIndex].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
