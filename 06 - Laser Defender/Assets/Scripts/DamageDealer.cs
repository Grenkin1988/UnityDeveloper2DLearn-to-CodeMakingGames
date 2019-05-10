using UnityEngine;

public class DamageDealer : MonoBehaviour {
    [SerializeField]
    private int _damage = 100;

    public int Damage => _damage;

    public void Hit() => Destroy(gameObject);
}
