using UnityEngine;

public class MusicManager : MonoBehaviour {
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
}
