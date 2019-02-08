using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour {

    [SerializeField] private Animator fader;
    [SerializeField] private string nextLevel;
    private Button button;

    private void Awake() {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(Transition()));
    }

    IEnumerator Transition() {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(nextLevel);
    }
}
