using ContextInput;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour {
    [SerializeField] private KeyCode nextLevelKey = KeyCode.None;
    [SerializeField] private string nextLevel;
    private Animator fader;
    private Button button;

    private void Awake() {
        fader = GameObject.Find("Fader").GetComponent<Animator>();
        if (nextLevel == string.Empty) nextLevel = SceneManager.GetActiveScene().name;
        button = GetComponent<Button>();
        button.onClick.AddListener(MakeTransition);
    }

    private void Update() {
        if (Input.GetKeyDown(nextLevelKey)) MakeTransition();
    }

    private void MakeTransition() {
        StartCoroutine(Transition());
    }

    IEnumerator Transition() {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(nextLevel);
    }
}