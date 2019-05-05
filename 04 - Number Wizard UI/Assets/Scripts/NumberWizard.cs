using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour {
    [SerializeField]
    private int _maxNumber;
    [SerializeField]
    private int _minNumber;
    private int _guess;

    [SerializeField]
    private TMP_Text _guessText;

    public void OnPressHigher() {
        _minNumber = _guess;
        NextGuess();
    }

    public void OnPressLower() {
        _maxNumber = _guess;
        NextGuess();
    }

    private void UpdateGuessText() {
        _guessText.text = $"{_guess}";
    }

    private void Start() {
        StartGame();
    }

    private void StartGame() {
        _maxNumber = _maxNumber + 1;
        NextGuess();
    }

    private void NextGuess() {
        _guess = (_maxNumber + _minNumber) / 2;
        UpdateGuessText();
    }
}
