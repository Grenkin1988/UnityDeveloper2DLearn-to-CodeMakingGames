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
    private int _numberOfEnemies = 5;
    [SerializeField]
    private float _moveSpeed = 2f;

    public GameObject EnemyPrefab => _enemyPrefab;
    public GameObject PathPrefab => _pathPrefab;
    public float TimeBetweenSpawns => _timeBetweenSpawns;
    public int NumberOfEnemies => _numberOfEnemies;
    public float MoveSpeed => _moveSpeed;

    public IEnumerable<Transform> GetWaypoints() {
        foreach (Transform child in PathPrefab.transform) {
            yield return child;
        }   
    }

    public static WaveConfig CreateWave(
        GameObject enemyPrefab,
        GameObject pathPrefab,
        float timeBetweenSpawns,
        int numberOfEnemies,
        float moveSpeed) {
        var config = new WaveConfig {
            _enemyPrefab = enemyPrefab,
            _pathPrefab = pathPrefab,
            _timeBetweenSpawns = timeBetweenSpawns,
            _numberOfEnemies = numberOfEnemies,
            _moveSpeed = moveSpeed
        };
        return config;
    }
}
