using System;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    private Paddle _paddle1;
    [SerializeField]
    private float _initialXVelocity = 2f;
    [SerializeField]
    private float _initialYVelocity = 15f;

    private Vector2 _paddleToBallVector;
    private bool _hasStarted = false;

    private Rigidbody2D _ballRigidbody2D;

    private void Start() {
        _paddleToBallVector = transform.position - _paddle1.transform.position;
        _ballRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!_hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            _hasStarted = true;
            _ballRigidbody2D.velocity = new Vector2(_initialXVelocity, _initialYVelocity);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = _paddle1.transform.position;
        transform.position = paddlePos + _paddleToBallVector;
    }
}
