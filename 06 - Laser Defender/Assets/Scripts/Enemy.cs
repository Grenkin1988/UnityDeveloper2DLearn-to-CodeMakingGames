using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("Enemy")]
    [SerializeField]
    private float _health = 100.0f;
    [SerializeField]
    private float _exposionDestroyTimeout = 1.0f;
    [SerializeField]
    private GameObject _destroyVFX;
    [SerializeField]
    private AudioClip _deathSound;
    [Range(0f, 1f), SerializeField]
    private float _deathSoundVolume = 0.7f;

    [Header("Shooting")]
    [SerializeField]
    private float _minTimeBetweenShots = 0.2f;
    [SerializeField]
    private float _maxTimeBetweenShots = 3.0f;
    [SerializeField]
    private float _projectileSpeed = 10f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private AudioClip _shootingSound;
    [Range(0f, 1f), SerializeField]
    private float _shootingSoundVolume = 0.7f;

    [SerializeField]
    private float _shootCounter;

    private Camera _mainCamera;

    // Start is called before the first frame update
    private void Start() {
        _mainCamera = Camera.main;
        SetShootCounter();
    }

    // Update is called once per frame
    private void Update() {
        CountDownAndShoot();
    }

    private void CountDownAndShoot() {
        _shootCounter -= Time.deltaTime;
        if(_shootCounter <= 0) {
            Fire();
            SetShootCounter();
        }
    }

    private void SetShootCounter() => _shootCounter = Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);

    private void Fire() {
        GameObject laser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -_projectileSpeed);
        AudioSource.PlayClipAtPoint(_shootingSound, _mainCamera.transform.position, _shootingSoundVolume);
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
        GameObject explosion = Instantiate(_destroyVFX, transform.position, transform.rotation);
        Destroy(explosion, _exposionDestroyTimeout);
    }
}
