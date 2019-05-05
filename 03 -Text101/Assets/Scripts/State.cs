using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {
    [TextArea(10, 14)]
    [SerializeField]
    private string _storyText;

    [SerializeField]
    private State[] _nextStates;

    public string GetStoryText() {
        return _storyText;
    }

    public State[] GetNextStates() {
        return _nextStates;
    }
}
