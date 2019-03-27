using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {

    [SerializeField] private int amtOfTimeInSeconds;

    private float elapsed = 0;

    private Animator fader;

    private void Awake() {
        fader = GameObject.Find("Fader").GetComponent<Animator>();
    }

    private void Update() {
        if (elapsed > amtOfTimeInSeconds) {
            if (SceneManager.GetActiveScene().name == "Level 4.1") {
                StartCoroutine(Transition("Ending"));
                return;
            }
            if (SceneManager.GetActiveScene().name == "Ending") {
                StartCoroutine(Transition("MainMenu"));
                return;
            }
            StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else elapsed += Time.deltaTime;
    }

    private IEnumerator Transition(string scene) {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(scene);
    }

    private IEnumerator Transition(int sceneBuildIndex) {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
