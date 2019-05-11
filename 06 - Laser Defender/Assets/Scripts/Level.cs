using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    [SerializeField]
    private float _gameOverDelay = 3.0f;

    public void LoadGameOver() => StartCoroutine(LoadGameOverWithDelay());

    private IEnumerator LoadGameOverWithDelay() {
        yield return new WaitForSeconds(_gameOverDelay);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGameScreen() => SceneManager.LoadScene("Game");

    public void LoadStartMenu() => SceneManager.LoadScene("StartMenu");

    public void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
