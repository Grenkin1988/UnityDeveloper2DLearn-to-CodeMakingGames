using System.Collections;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
    [SerializeField]
    private float _startScreenDelay = 3.0f;

    private IEnumerator Start() {
        yield return new WaitForSeconds(_startScreenDelay);
        LevelManager.LoadMainMenu();
    }
}
