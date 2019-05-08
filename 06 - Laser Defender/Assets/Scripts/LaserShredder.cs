using UnityEngine;

public class LaserShredder : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D col) {
        Destroy(col.gameObject);
    }
}
