using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField]
    private Projectile _projectilePrefab;
    [SerializeField]
    private Transform _gunPosition;

    private AttackerSpawner _myLaneSpawner;

    private void Start() {
        SetLaneSpawner();
    }

    private void Update() {
        if (IsAttackerInLane()) {
            Debug.Log("PEW PEW PEW");
        } else {
            Debug.Log("Sit");
        }
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners) {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough) {
                _myLaneSpawner = spawner;
                break;
            }
        }
    }

    private bool IsAttackerInLane() => _myLaneSpawner.transform.childCount > 0;

    public void Fire() {
        Instantiate(_projectilePrefab, _gunPosition.transform.position, _gunPosition.transform.rotation);
    }
}
