using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField]
    private AudioClip _breakSound;

    private Level _level;

    private void Start() {
        _level = FindObjectOfType<Level>();
        _level.AddBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(_breakSound, transform.position);
        _level.RemoveBreakableBlocks();
        Destroy(gameObject);
    }
}
