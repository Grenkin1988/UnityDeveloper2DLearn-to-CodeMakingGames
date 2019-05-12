using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float _speed = 5f;

    private void Update() {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}
