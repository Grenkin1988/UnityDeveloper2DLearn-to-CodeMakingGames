using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    [Range(0f, 10f), SerializeField]
    private float _moveSpeed = 1f;

    private void Start() {

    }

    private void Update() {
        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
    }
}
