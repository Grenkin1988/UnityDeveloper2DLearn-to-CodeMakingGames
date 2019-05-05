using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    private Paddle _paddle1;

    private Vector2 _paddleToBallVector;

    private void Start() {
        _paddleToBallVector = transform.position - _paddle1.transform.position;
    }

    private void Update() {
        Vector2 paddlePos = _paddle1.transform.position;
        transform.position = paddlePos + _paddleToBallVector;
    }
}
