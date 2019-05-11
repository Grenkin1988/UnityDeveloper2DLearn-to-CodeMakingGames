using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    public void LoadGameOver() => SceneManager.LoadScene("GameOver");

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
