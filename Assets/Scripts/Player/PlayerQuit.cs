using UnityEngine;
using System;
using ContextInput;

public class PlayerQuit : MonoBehaviour {
    private Action quit = () => Application.Quit();

    private void OnEnable() {
        PlayerInput.Quit += quit;
    }

    private void OnDisable() {
        PlayerInput.Quit -= quit;
    }
}
