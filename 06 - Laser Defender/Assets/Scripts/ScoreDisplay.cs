using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {
    private TextMeshProUGUI _scoreText;
    private GameSession _currentSession;

    private void Start() {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _currentSession = FindObjectOfType<GameSession>();
        UpdateText();
    }

    private void Update() {
        UpdateText();
    }

    private void UpdateText() {
        _scoreText.text = $"{_currentSession.Score}";
    }
}
