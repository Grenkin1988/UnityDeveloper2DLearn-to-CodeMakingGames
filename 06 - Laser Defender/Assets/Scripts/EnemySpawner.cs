using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [Header("Main Config")]
    [SerializeField]
    private List<WaveConfig> _waveConfigs;
    [SerializeField]
    private int _startingWave;
    [SerializeField]
    private bool _looping = false;

    [Header("Random Wave Config")]
    [SerializeField]
    private bool _shouldRandomizeWaves = false;
    [SerializeField]
    private int _numberOfWavesToGenerate = 20;
    [SerializeField]
    private float _simpleEnemyChance = 0.5f;
    [SerializeField]
    private float _fastEnemyChance = 0.3f;
    [SerializeField]
    private float _bigEnemyChance = 0.2f;
    [Header("Prefabs")]
    [SerializeField]
    private List<GameObject> _simpleEnemyPrefabs;
    [SerializeField]
    private List<GameObject> _fastEnemyPrefabs;
    [SerializeField]
    private List<GameObject> _bigEnemyPrefabs;
    [SerializeField]
    private List<GameObject> _paths;
    [Header("Speed")]
    [SerializeField]
    private float _simpleEnemySpeed = 10f;
    [SerializeField]
    private float _fastEnemySpeed = 15f;
    [SerializeField]
    private float _bigEnemySpeed = 6f;
    [SerializeField]
    private float _speedRandomness = 2f;
    [Header("Number of Enemies")]
    [SerializeField]
    private int _minNumberOfEnemies = 5;
    [SerializeField]
    private int _maxNumberOfEnemies = 20;
    [Header("Time between spawns")]
    [SerializeField]
    private float _minTimeBetweenSpawns = 0.2f;
    [SerializeField]
    private float _maxTimeBetweenSpawns = 2f;


    private IEnumerator Start() {
        if (_shouldRandomizeWaves) {
            CreateRandomWaves();
        }
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while (_looping);
    }

    private IEnumerator SpawnAllWaves() {
        for (int waveIndex = _startingWave; waveIndex < _waveConfigs.Count; waveIndex++) {
            Coroutine startWave = StartCoroutine(SpawnAllEnemiesInWave(_waveConfigs[waveIndex]));
            yield return startWave;
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {
        for (int i = 0; i < waveConfig.NumberOfEnemies; i++) {
            GameObject enemy = Instantiate(waveConfig.EnemyPrefab, waveConfig.GetWaypoints().First().position, Quaternion.identity);
            EnemyPathing pathing = enemy.GetComponent<EnemyPathing>();
            pathing.SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }

    private void CreateRandomWaves() {
        float simpleEnemyChance = _simpleEnemyChance;
        float fastEnemyChance = _simpleEnemyChance + _fastEnemyChance;
        float bigEnemyChance = _simpleEnemyChance + _fastEnemyChance + _bigEnemyChance;

        _waveConfigs = new List<WaveConfig>();
        for (int i = 0; i < _numberOfWavesToGenerate; i++) {
            float waveType = Random.Range(0f, 1f);
            if(waveType < simpleEnemyChance) {
                var config = CreateSimpleWave();
                _waveConfigs.Add(config);
            } else if(waveType >= simpleEnemyChance && waveType < fastEnemyChance) {
                var config = CreateFastWave();
                _waveConfigs.Add(config);
            } else if(waveType >= fastEnemyChance && waveType <= bigEnemyChance) {
                var config = CreateBigWave();
                _waveConfigs.Add(config);
            }
        }
    }

    private WaveConfig CreateSimpleWave() {
        GameObject enemyPrefab = _simpleEnemyPrefabs[Random.Range(0, _simpleEnemyPrefabs.Count)];
        GameObject pathPrefab = _paths[Random.Range(0, _paths.Count)];
        float timeBetweenSpawns = Mathf.Clamp(Random.Range(_minTimeBetweenSpawns, _maxTimeBetweenSpawns), _minTimeBetweenSpawns, 0.8f);
        int numberOfEnemies = Random.Range(_minNumberOfEnemies, _maxNumberOfEnemies);
        float moveSpeed = _simpleEnemySpeed + Random.Range(-_speedRandomness, _speedRandomness);

        return WaveConfig.CreateWave(enemyPrefab, pathPrefab, timeBetweenSpawns, numberOfEnemies, moveSpeed);
    }

    private WaveConfig CreateFastWave() {
        GameObject enemyPrefab = _fastEnemyPrefabs[Random.Range(0, _fastEnemyPrefabs.Count)];
        GameObject pathPrefab = _paths[Random.Range(0, _paths.Count)];
        float timeBetweenSpawns = Mathf.Clamp(Random.Range(_minTimeBetweenSpawns, _maxTimeBetweenSpawns), _minTimeBetweenSpawns, 0.5f);
        int numberOfEnemies = Random.Range(_minNumberOfEnemies, _maxNumberOfEnemies);
        float moveSpeed = _fastEnemySpeed + Random.Range(-_speedRandomness, _speedRandomness);

        return WaveConfig.CreateWave(enemyPrefab, pathPrefab, timeBetweenSpawns, numberOfEnemies, moveSpeed);
    }

    private WaveConfig CreateBigWave() {
        GameObject enemyPrefab = _bigEnemyPrefabs[Random.Range(0, _bigEnemyPrefabs.Count)];
        GameObject pathPrefab = _paths[Random.Range(0, _paths.Count)];
        float timeBetweenSpawns = Mathf.Clamp(Random.Range(_minTimeBetweenSpawns, _maxTimeBetweenSpawns), _minTimeBetweenSpawns, 1.5f);
        int numberOfEnemies = Random.Range(_minNumberOfEnemies, _maxNumberOfEnemies);
        float moveSpeed = _bigEnemySpeed + Random.Range(-_speedRandomness, _speedRandomness);

        return WaveConfig.CreateWave(enemyPrefab, pathPrefab, timeBetweenSpawns, numberOfEnemies, moveSpeed);
    }
}
