using UnityEngine;
using ContextInput;
using UnityEngine.SceneManagement;

public class PlayerSwitchScenes : MonoBehaviour {
    private void OnEnable() {
        PlayerInput.SwitchScenes += SceneSwitch;
    }

    private void OnDisable() {
        PlayerInput.SwitchScenes -= SceneSwitch;
    }

    private void SceneSwitch(int index) {
        SceneManager.LoadScene(index+1);
    }
}
