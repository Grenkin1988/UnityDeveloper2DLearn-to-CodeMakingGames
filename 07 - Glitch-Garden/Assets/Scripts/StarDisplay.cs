using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {
    [SerializeField]
    private int _stars = 100;

    private Text _starText;

    public void AddStars(int stars) {
        _stars += stars;
        UpdateDisplay();
    }

    public void RemoveStars(int stars) {
        if (_stars >= stars) {
            _stars -= stars;
            UpdateDisplay();
        }
    }

    private void Start() {
        _starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        _starText.text = $"{_stars}";
    }
}
