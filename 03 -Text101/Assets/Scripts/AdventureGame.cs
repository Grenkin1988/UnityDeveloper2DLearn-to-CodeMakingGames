using System;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {
    [SerializeField]
    private Text _textComponent;

    [SerializeField]
    private State _startingState;

    private State _state;

    private void Start() {
        _state = _startingState;
        _textComponent.text = _state?.GetStoryText();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            QuitGame();
        }
        ManageState();
    }

    private void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void ManageState() {
        State[] nextStates = _state?.GetNextStates();
        if(nextStates == null || nextStates.Length == 0) { return; }
        for (int i = 0; i < nextStates.Length; i++) {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i)) {
                _state = nextStates[i];
                _textComponent.text = _state?.GetStoryText();
            }
        }
    }
}
