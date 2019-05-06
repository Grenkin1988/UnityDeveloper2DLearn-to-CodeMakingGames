using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [Range(0.1f, 16f)]
    [SerializeField]
    private float gameSpeed = 1f;
    [SerializeField]
    private int pointsPerBlockRemoved = 20;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private int currentScore = 0;

    private void Awake() {
        int gameGameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameGameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        UpdateScoreText();
    }

    private void Update() {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() {
        currentScore += pointsPerBlockRemoved;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        scoreText.text = $"{currentScore}";
    }
}
