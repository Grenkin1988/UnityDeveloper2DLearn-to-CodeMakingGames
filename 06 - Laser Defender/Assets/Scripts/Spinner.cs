using UnityEngine;

public class Spinner : MonoBehaviour {
    [SerializeField]
    private float _speedOfSpin;

    private void Update() {
        transform.Rotate(new Vector3(0, 0, _speedOfSpin * Time.deltaTime));
    }
}
