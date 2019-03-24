using ContextInput;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSkipLevelDebug : MonoBehaviour {
    private void OnEnable() {
        PlayerInput.DebugSkipLevel += SkipLevel;
        PlayerInput.DebugLastLevel += LastLevel;
    }

    private void OnDisable() {
        PlayerInput.DebugSkipLevel -= SkipLevel;
        PlayerInput.DebugLastLevel -= LastLevel;

    }

    private void SkipLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void LastLevel() {
        try { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); }
        catch { }
    }
}