using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _damage = 100f;

    private void Update() {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Health health = other.gameObject.GetComponent<Health>();
        ProcessHit(health);
    }

    private void ProcessHit(Health health) {
        if (health == null) { return; }
        health.DealDamage(_damage);
        Die();
    }

    private void Die() {
        Destroy(gameObject);
    }
}
