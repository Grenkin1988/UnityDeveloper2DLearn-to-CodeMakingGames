using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField]
    private AudioClip breakSound;

    private Level level;
    private GameSession gameStatus;

    private void Start() {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        level.AddBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        gameStatus.AddToScore();
        level.RemoveBreakableBlocks();
        Destroy(gameObject);
    }
}
