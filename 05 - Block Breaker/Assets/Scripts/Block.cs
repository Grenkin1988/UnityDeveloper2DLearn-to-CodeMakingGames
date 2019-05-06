using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField]
    private AudioClip breakSound;

    private Level level;
    private GameStatus gameStatus;

    private void Start() {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        level.AddBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        gameStatus.AddToScore();
        level.RemoveBreakableBlocks();
        Destroy(gameObject);
    }
}
