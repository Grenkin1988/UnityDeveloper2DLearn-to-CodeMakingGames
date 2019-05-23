using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    private Defender _selectedDefender;

    private void Start() {

    }

    private void OnMouseDown() {
        Vector2 worldPos = GetSquareClicked();
        AttemtToPlaceDefender(worldPos);
    }

    public void SetDefender(Defender defender) => _selectedDefender = defender;

    public void AttemtToPlaceDefender(Vector2 gridPos) {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        int starCost = _selectedDefender.StarCost;
        if (starDisplay.HaveEnoughStars(starCost)) {
            SpawnDefender(gridPos);
            starDisplay.RemoveStars(starCost);
        }
    }

    private Vector2 GetSquareClicked() {
        var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float nexX = Mathf.RoundToInt(rawWorldPos.x);
        float nexY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(nexX, nexY);
    }

    private void SpawnDefender(Vector2 roundedPos) {
        Defender newDefender = Instantiate(_selectedDefender, roundedPos, Quaternion.identity);
    }
}
