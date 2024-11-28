using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyFactory))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    private int _pointCount = 0;
    private float _waitTime = 2f;
    private WaitForSeconds _wait;
    private EnemyFactory _enemyFactory;

    private void Awake()
    {
        _enemyFactory = GetComponent<EnemyFactory>();
        _wait = new WaitForSeconds(_waitTime);
        StartCoroutine(CreateEnemyWithWait());
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
    }

    private IEnumerator CreateEnemyWithWait()
    {
        while (true)
        {
            Enemy enemy = _enemyFactory.Create();
            enemy.transform.position = GetRandomSpawnPoint();
            enemy.Init(Vector3.forward);
            yield return _wait;
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _pointCount = transform.childCount;
        _spawnPoints = new Transform[_pointCount];

        for (int i = 0; i < _pointCount; i++)
            _spawnPoints[i] = transform.GetChild(i);
    }
#endif
}