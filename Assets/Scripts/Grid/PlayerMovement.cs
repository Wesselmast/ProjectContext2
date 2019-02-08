using System;
using System.Collections;
using ContextInput;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private WingDetection self, gun;
    [SerializeField] private Animator fader;

    private Grid grid;
    string scene;

    private void Awake() {
        scene = SceneManager.GetActiveScene().name;
        grid = FindObjectOfType<Grid>();
        PlayerInput.Rotate += Rotate;
        PlayerInput.Reset += ResetLevel;
    }

    IEnumerator Transition() {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(scene);
    }

    public void ResetLevel() {
        StartCoroutine(Transition());
    }

    private void OnDisable() {
        PlayerInput.Rotate -= Rotate;
        PlayerInput.Reset -= ResetLevel;
    }

    private void Rotate(Direction dir) {
        if (dir == Direction.Left && (self.LocalLeft && gun.LocalLeft)) {
            transform.eulerAngles -= Vector3.up * 90;
        }
        else if (dir == Direction.Right && (self.LocalRight && gun.LocalRight)) {
            transform.eulerAngles += Vector3.up * 90;
        }
    }
    private void Update() {
        if (gun.gameObject.activeInHierarchy) {
            if (gun.Forward && self.Forward && PlayerInput.Horizontal < 0) transform.position += Vector3.forward;
            if (gun.Back && self.Back && PlayerInput.Horizontal > 0) transform.position += Vector3.back;
            if (gun.Left && self.Left && PlayerInput.Vertical < 0) transform.position += Vector3.left;
            if (gun.Right && self.Right && PlayerInput.Vertical > 0) transform.position += Vector3.right;
        }
        else {
            if (self.Forward && PlayerInput.Horizontal < 0) transform.position += transform.forward;
            if (self.Back && PlayerInput.Horizontal > 0) transform.position -= transform.forward;
            if (self.Left && PlayerInput.Vertical < 0) transform.position -= transform.right;
            if (self.Right && PlayerInput.Vertical > 0) transform.position += transform.right;

        }
    }
}