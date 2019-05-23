using UnityEngine;

public class Defender : MonoBehaviour {
    [SerializeField]
    private int _starCost = 100;

    public int StarCost => _starCost;

    public void AddStars(int amount) => FindObjectOfType<StarDisplay>().AddStars(amount);
}
