using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntro : MonoBehaviour {

    [SerializeField] private KeyCode skipKey;

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if(Input.GetKeyDown(skipKey) || Input.GetKeyDown(KeyCode.Mouse0)) {
            StartCoroutine(Out());
        }
    }

    private IEnumerator Out() {
        anim.Play("IntroFadeIn");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
