using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField]
    private float _minSpawnDelay = 1f;
    [SerializeField]
    private float _maxSpawnDelay = 5f;
    [SerializeField]
    private Attacker _attackerPrefab;

    private bool _doSpawn = true;

    private IEnumerator Start() {
        while (_doSpawn) {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker() {
        Instantiate(_attackerPrefab, transform.position, transform.rotation);
    }

    private void Update() {

    }
}
