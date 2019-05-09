using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _pathPrefab;
    [SerializeField]
    private float _timeBetweenSpawns = 0.5f;
    [SerializeField]
    private float _spawnRandomFactor = 0.3f;
    [SerializeField]
    private int _numberOfEnemies = 5;
    [SerializeField]
    private float _moveSpeed = 2f;

    public GameObject EnemyPrefab => _enemyPrefab;
    public GameObject PathPrefab => _pathPrefab;
    public float TimeBetweenSpawns => _timeBetweenSpawns;
    public float SpawnRandomFactor => _spawnRandomFactor;
    public int NumberOfEnemies => _numberOfEnemies;
    public float MoveSpeed => _moveSpeed;

    public IEnumerable<Transform> GetWaypoints() {
        foreach (Transform child in PathPrefab.transform) {
            yield return child;
        }   
    }
}
