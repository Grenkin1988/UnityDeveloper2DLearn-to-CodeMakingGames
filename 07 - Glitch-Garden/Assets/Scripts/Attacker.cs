using UnityEngine;

public class Attacker : MonoBehaviour {
    private float _currentSpeed = 1f;

    private void Start() {

    }

    private void Update() {
        transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed) {
        _currentSpeed = speed;
    }
}
