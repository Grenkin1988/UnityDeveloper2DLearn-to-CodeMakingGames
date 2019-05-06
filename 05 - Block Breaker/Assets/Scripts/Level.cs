using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField]
    private int breakableBlocks;

    private SceneLoader sceneLoader;

    public void AddBlockToCount() {
        breakableBlocks++;
    }

    public void RemoveBreakableBlocks() {
        breakableBlocks--;
        if (breakableBlocks <= 0) {
            sceneLoader.LoadNextScene();
        }
    }

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void Update() {

    }
}
