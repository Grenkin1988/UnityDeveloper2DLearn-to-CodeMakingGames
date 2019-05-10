using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private float _health = 100.0f;

    // Start is called before the first frame update
    private void Start() {

    }

    // Update is called once per frame
    private void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(damageDealer == null) { return; }
        _health -= damageDealer.Damage;
        damageDealer.Hit();
        if (_health <= 0) {
            Die();
        }
    }

    private void Die() => Destroy(gameObject);
}
