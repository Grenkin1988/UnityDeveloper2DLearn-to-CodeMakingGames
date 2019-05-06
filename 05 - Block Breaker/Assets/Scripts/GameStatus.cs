using UnityEngine;

public class GameStatus : MonoBehaviour {

    [Range(0.1f, 16f)]
    [SerializeField]
    private float gameSpped = 1f;

    private void Start() {

    }

    private void Update() {
        Time.timeScale = gameSpped;
    }
}
