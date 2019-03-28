using System.Collections;
using UnityEngine;

public class SkipIntro : MonoBehaviour {

    [SerializeField] private KeyCode skipKey;
    [SerializeField] private string eventName;

    private FMOD.Studio.EventInstance myEvent;

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
        myEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Characters/" + eventName);
        myEvent.start();
    }

    private void Update() {
        if(Input.GetKeyDown(skipKey) || Input.GetKeyDown(KeyCode.Mouse0)) {
            myEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            StartCoroutine(Out());
        }
    }

    private IEnumerator Out() {
        anim.Play("IntroFadeIn");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
