﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseColider : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        SceneManager.LoadScene("Game Over");
    }
}
