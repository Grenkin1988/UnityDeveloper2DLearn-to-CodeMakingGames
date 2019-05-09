using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    private WaveConfig _waveConfig;
    private int _waypointIndex = 0;
    private List<Transform> _waypoints;

    public void SetWaveConfig(WaveConfig waveConfig) {
        _waveConfig = waveConfig;
        SetupWaypoints();
    }

    private void SetupWaypoints() {
        _waypoints = new List<Transform>(_waveConfig.GetWaypoints());
        transform.position = _waypoints[_waypointIndex].transform.position;
    }

    private void Update() {
        Move();
    }

    private void Move() {
        if (_waypointIndex <= _waypoints.Count - 1) {
            Vector3 targetPosition = _waypoints[_waypointIndex].transform.position;
            float movementThisFrame = _waveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition) {
                _waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
