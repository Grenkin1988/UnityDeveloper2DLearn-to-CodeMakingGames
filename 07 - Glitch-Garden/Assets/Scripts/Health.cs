using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    private float _health = 100f;
    [SerializeField]
    private float _exposionDestroyTimeout = 1.0f;
    [SerializeField]
    private GameObject _destroyVFX;

    public void DealDamage(float damage) {
        _health -= damage;
        if(_health <= 0) {
            Die();
        }
    }

    private void Die() {
        GameObject explosion = Instantiate(_destroyVFX, transform.position, transform.rotation);
        Destroy(explosion, _exposionDestroyTimeout);
        Destroy(gameObject);
    }
}
