using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _defender;

    private void Start()
    {
        
    }

    private void OnMouseDown() {
        Vector2 worldPos = GetSquareClicked();
        SpawnDefender(worldPos);
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private void SpawnDefender(Vector2 worldPos) {
        
        GameObject newDefender = Instantiate(_defender, worldPos, Quaternion.identity);
    }
}
