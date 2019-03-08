using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtIntro : MonoBehaviour {
    [SerializeField] private Animator intro;

    private void Awake() {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Clicked);
    }

    private void Clicked() {
        intro.gameObject.SetActive(true);
        intro.Play("IntroFadeOut");
    }
}
