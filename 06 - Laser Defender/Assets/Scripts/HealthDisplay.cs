using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour {
    private TextMeshProUGUI _healthText;
    private Player _currentPlayer;

    private void Start() {
        _healthText = GetComponent<TextMeshProUGUI>();
        _currentPlayer = FindObjectOfType<Player>();
        UpdateText();
    }

    private void Update() {
        UpdateText();
    }

    private void UpdateText() {
        _healthText.text = $"{_currentPlayer.Health}";
    }
}
