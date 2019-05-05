using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour {
    [SerializeField]
    private int _maxNumber;
    [SerializeField]
    private int _minNumber;
    private int _guess;

    [SerializeField]
    private TextMeshProUGUI _guessText;

    public void OnPressHigher() {
        _minNumber = Mathf.Clamp(_guess + 1, _minNumber, _maxNumber);
        NextGuess();
    }

    public void OnPressLower() {
        _maxNumber = Mathf.Clamp(_guess - 1, _minNumber, _maxNumber);
        NextGuess();
    }

    private void UpdateGuessText() {
        _guessText.text = $"{_guess}";
    }

    private void Start() {
        StartGame();
    }

    private void StartGame() {
        NextGuess();
    }

    private void NextGuess() {
        _guess = Random.Range(_minNumber, _maxNumber + 1);
        UpdateGuessText();
    }
}
