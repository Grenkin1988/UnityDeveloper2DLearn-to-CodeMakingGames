using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    [SerializeField]
    private WaveConfig _waveConfig;
    [SerializeField]
    private float _moveSpeed = 2f;

    private int _waypointIndex = 0;
    private List<Transform> _waypoints;

    // Start is called before the first frame update
    private void Start() {
        _waypoints = new List<Transform>(_waveConfig.GetWaypoints());
        transform.position = _waypoints[_waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update() {
        Move();
    }

    private void Move() {
        if (_waypointIndex <= _waypoints.Count - 1) {
            Vector3 targetPosition = _waypoints[_waypointIndex].transform.position;
            float movementThisFrame = _moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition) {
                _waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
