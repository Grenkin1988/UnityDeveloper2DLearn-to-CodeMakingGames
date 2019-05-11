using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Player")]
    [SerializeField]
    private float _movementSpeed = 10f;
    [SerializeField]
    private float _paddingX = 1f;
    [SerializeField]
    private float _paddingY = 1f;
    [SerializeField]
    private int _health = 200;
    [SerializeField]
    private AudioClip _deathSound;
    [Range(0f, 1f),SerializeField]
    private float _deathSoundVolume = 0.7f;

    [Header("Projectile")]
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _projectileSpeed = 10f;
    [SerializeField]
    private float _projectileFiringPeriod = 0.2f;
    [SerializeField]
    private AudioClip _shootingSound;
    [Range(0f, 1f), SerializeField]
    private float _shootingSoundVolume = 0.7f;

    private Camera _mainCamera;
    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;
    private Coroutine _firingCoroutine;

    public int Health => _health;

    private void Start() {
        _mainCamera = Camera.main;
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    private void Update() {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        if (damageDealer == null) { return; }
        _health -= damageDealer.Damage;
        damageDealer.Hit();
        if (_health <= 0) {
            Die();
        }
    }

    private void Die() {
        AudioSource.PlayClipAtPoint(_deathSound, _mainCamera.transform.position, _deathSoundVolume);
        Destroy(gameObject);
        FindObjectOfType<Level>().LoadGameOver();
    }

    private void Move() {
        float deltaX = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, _xMin, _xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, _yMin, _yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            _firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(_firingCoroutine);
        }
    }

    private IEnumerator FireContinuously() {
        while (true) {
            GameObject laser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _projectileSpeed);
            AudioSource.PlayClipAtPoint(_shootingSound, _mainCamera.transform.position, _shootingSoundVolume);
            yield return new WaitForSeconds(_projectileFiringPeriod);
        }
    }

    private void SetUpMoveBoundaries() {
        _xMin = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _paddingX;
        _xMax = _mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _paddingX;
        _yMin = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _paddingY;
        _yMax = _mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _paddingY;
    }
}
