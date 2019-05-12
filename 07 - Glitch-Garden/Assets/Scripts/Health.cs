using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    private float _health = 100f;

    public void DealDamage(float damage) {
        _health -= damage;
        if(_health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
