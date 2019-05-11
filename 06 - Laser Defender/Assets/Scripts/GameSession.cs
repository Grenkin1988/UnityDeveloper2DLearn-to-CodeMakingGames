using UnityEngine;

public class GameSession : MonoBehaviour {
    int _score = 0;

    public int Score => _score;

    private void Awake() {
        SetUpSingleton();
    }

    private void SetUpSingleton() {
        int gameGameStatusCount = FindObjectsOfType(GetType()).Length;
        if (gameGameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int scoreToAdd) {
        _score += scoreToAdd;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }
}
