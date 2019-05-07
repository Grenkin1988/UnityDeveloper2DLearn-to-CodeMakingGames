using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {

    [SerializeField]
    private Paddle paddle1;
    [SerializeField]
    private float initialXVelocity = 2f;
    [SerializeField]
    private float initialYVelocity = 15f;
    [SerializeField]
    private AudioClip[] bounceAudioClips;
    [SerializeField]
    private float randomeFactor = 0.2f;

    private Vector2 paddleToBallVector;
    private bool hasStarted = false;

    private Rigidbody2D ballRigidbody2D;
    private AudioSource audioSource;

    private void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
        ballRigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            ballRigidbody2D.velocity = new Vector2(initialXVelocity, initialYVelocity);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = paddle1.transform.position;
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityChange = new Vector2(Random.Range(-randomeFactor, randomeFactor), Random.Range(-randomeFactor, randomeFactor));
        if (hasStarted) {
            ballRigidbody2D.velocity += velocityChange;
            PlayCollisionClip();
        }
    }

    private void PlayCollisionClip() {
        if (bounceAudioClips != null && bounceAudioClips.Length > 0) {
            var clip = bounceAudioClips[Random.Range(0, bounceAudioClips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
