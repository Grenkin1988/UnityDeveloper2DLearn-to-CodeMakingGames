using UnityEngine;

public class Paddle : MonoBehaviour {
    //[SerializeField]
    //private float _screenWidthInUnits = 16;
    [SerializeField]
    private float _minX = 1f;
    [SerializeField]
    private float _maxX = 15f;

    [SerializeField]
    private Camera _mainCamera;

    private void Update() {
        Vector3 mouse = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        //float newX = Input.mousePosition.x / Screen.width * _screenWidthInUnits;
        var paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mouse.x, _minX, _maxX);
        transform.position = paddlePos;
    }
}
