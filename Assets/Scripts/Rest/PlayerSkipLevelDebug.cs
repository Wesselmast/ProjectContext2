using ContextInput;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSkipLevelDebug : MonoBehaviour {
    private void OnEnable() {
        PlayerInput.DebugSkipLevel += SkipLevel;
    }

    private void OnDisable() {
        PlayerInput.DebugSkipLevel -= SkipLevel;
    }

    private void SkipLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}