using System;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField]
    private AudioClip breakSound;
    [SerializeField]
    private GameObject blockSparkleVFX;   
    [SerializeField]
    private Sprite[] hitSprites;

    private Level level;
    private GameSession gameStatus;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private int timesHit;
    private int maxHits;

    private void Start() {
        gameStatus = FindObjectOfType<GameSession>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        maxHits = hitSprites != null ? hitSprites.Length + 1 : 1;
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
            HandleHit();
        }
    }

    private void HandleHit() {
        timesHit++;
        if (timesHit >= maxHits) {
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        if(hitSprites == null || hitSprites.Length == 0) {
            return;
        }
        int spriteIndex = Mathf.Clamp(timesHit - 1, 0, hitSprites.Length - 1);
        if (hitSprites[spriteIndex] != null) {
            spriteRenderer.sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError($"GameObject[{gameObject.name}] do not have sprite in hitSprites on index {spriteIndex}", gameObject);
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
