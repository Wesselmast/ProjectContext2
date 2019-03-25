using UnityEngine;

public class Protester : MonoBehaviour {

    private Animator animator;
    private float elapsed = 0;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (elapsed <= 0) {
            animator.SetFloat("ChanceToSwitch", Random.Range(0f, 1f));
            elapsed = Random.Range(1f, 5f);
        }
        else elapsed -= Time.deltaTime;
    }
}
