using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    private List<WaveConfig> _waveConfigs;

    private int _startingWave;

    // Start is called before the first frame update
    private void Start() {
        WaveConfig currentWave = _waveConfigs[_startingWave];
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves() {
        foreach (WaveConfig config in _waveConfigs) {
            Coroutine startWave = StartCoroutine(SpawnAllEnemiesInWave(config));
            yield return startWave;
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {
        for (int i = 0; i < waveConfig.NumberOfEnemies; i++) {
            GameObject enemy = Instantiate(waveConfig.EnemyPrefab, waveConfig.GetWaypoints().First().position, Quaternion.identity);
            var pathing = enemy.GetComponent<EnemyPathing>();
            pathing.SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }
}
