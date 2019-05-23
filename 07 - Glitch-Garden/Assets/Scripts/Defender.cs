using UnityEngine;

public class Defender : MonoBehaviour {
    [SerializeField]
    private int _starCost = 100;

    public void AddStars(int amount) {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }
}
