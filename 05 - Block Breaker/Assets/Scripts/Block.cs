using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField]
    private AudioClip breakSound;
    [SerializeField]
    private GameObject blockSparkleVFX;

    private Level level;
    private GameSession gameStatus;

    private void Start() {
        gameStatus = FindObjectOfType<GameSession>();
        CountBlock();
    }

    private void CountBlock() {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") {
            level.AddBlockToCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            DestroyBlock();
        }
    }

    private void DestroyBlock() {
        PlayEffects();
        gameStatus.AddToScore();
        level.RemoveBreakableBlocks();
        Destroy(gameObject);
    }

    private void PlayEffects() {
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2.0f);
    }
}
