using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    //PLACEHOLDER
    float count;
    [SerializeField] private Animator fader;
    [SerializeField] private GameObject weapon;
    [SerializeField] private string nextLevel;

    private void Start() {
        fader.Play("FadeIn");
        count = 3;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            count--;
        }
       
        if (count <= 0) {
            weapon.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (count <= 0 && other.tag == "Player") {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut() {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(nextLevel);

    }
}
