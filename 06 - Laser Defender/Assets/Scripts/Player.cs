using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private float _movementSpeed = 10f;
    [SerializeField]
    private float _paddingX = 1f;
    [SerializeField]
    private float _paddingY = 1f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _projectileSpeed = 10f;
    [SerializeField]
    private float _projectileFiringPeriod = 0.2f;

    private Camera _gameCamera;
    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;
    private Coroutine _firingCoroutine;

    // Start is called before the first frame update
    private void Start() {
        _gameCamera = Camera.main;
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    private void Update() {
        Move();
        Fire();
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
            yield return new WaitForSeconds(_projectileFiringPeriod);
        }
    }

    private void SetUpMoveBoundaries() {
        _xMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _paddingX;
        _xMax = _gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _paddingX;
        _yMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _paddingY;
        _yMax = _gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _paddingY;
    }
}
