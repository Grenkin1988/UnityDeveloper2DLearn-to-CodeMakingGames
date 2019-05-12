using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField]
    private Projectile _projectilePrefab;
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
