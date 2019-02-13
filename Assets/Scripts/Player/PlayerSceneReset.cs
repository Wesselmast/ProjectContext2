using ContextInput;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneReset : MonoBehaviour {

    private Animator fader;

    private void Awake() {
        fader = GameObject.Find("Fader").GetComponent<Animator>();
        PlayerInput.Reset += ResetLevel;
    }

    private void OnDisable() {
        PlayerInput.Reset -= ResetLevel;
    }

    private void ResetLevel() {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition() {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
