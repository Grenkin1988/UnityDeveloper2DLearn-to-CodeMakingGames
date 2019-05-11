using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    [SerializeField]
    private float _backgroundScrollSpeed = 0.5f;

    private Material _material;
    private Vector2 _offset;

    private void Start() {
        _material = GetComponent<Renderer>().material;
        _offset = new Vector2(0, _backgroundScrollSpeed);
    }

    private void Update() {
        _material.mainTextureOffset += _offset * Time.deltaTime;
    }
}
