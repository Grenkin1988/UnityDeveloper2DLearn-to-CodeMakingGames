using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private Transform _gunPosition;

    private void Start() {

    }

    private void Update() {

    }

    public void Fire() {
        Instantiate(_projectilePrefab, _gunPosition.transform.position, _gunPosition.transform.rotation);
    }
}
