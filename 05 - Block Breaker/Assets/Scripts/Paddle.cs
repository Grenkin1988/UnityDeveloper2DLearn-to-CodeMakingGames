using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField]
    private float _minX = 1f;
    [SerializeField]
    private float _maxX = 15f;
    [SerializeField]
    private Camera _mainCamera;

    private GameSession gameSession;
    private Ball ball;

    private void Start() {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    private void Update() {
        var paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = GetPaddleXPosition();
        transform.position = paddlePos;
    }

    private float GetPaddleXPosition() {
        if (gameSession.IsAutoPlayEnabled()) {
            return Mathf.Clamp(ball.transform.position.x, _minX, _maxX);
        } else {
            Vector3 mouse = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return Mathf.Clamp(mouse.x, _minX, _maxX);
        }
    }
}
