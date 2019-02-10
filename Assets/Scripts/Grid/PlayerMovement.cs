using System.Collections;
using ContextInput;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private WingDetection self, gun;
    [SerializeField] private Animator fader;
    [SerializeField] private Transform door;

    private Grid grid;
    string scene;

    private void Awake() {
        transform.position = door.position;
        transform.eulerAngles = new Vector3(door.eulerAngles.x, door.eulerAngles.y + 90, door.eulerAngles.z);
        scene = SceneManager.GetActiveScene().name;
        grid = FindObjectOfType<Grid>();
        PlayerInput.Rotate += Rotate;
        PlayerInput.Move += Move;
        PlayerInput.Reset += ResetLevel;
    }

    private IEnumerator Transition() {
        fader.Play("FadeOut");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(scene);
    }

    public void ResetLevel() {
        StartCoroutine(Transition());
    }

    private void OnDisable() {
        PlayerInput.Rotate -= Rotate;
        PlayerInput.Move -= Move;
        PlayerInput.Reset -= ResetLevel;
    }

    private void Rotate(Direction dir) {
        if (gun.gameObject.activeInHierarchy) {
            if (gun.Left && self.Left && dir == Direction.Left) transform.eulerAngles -= Vector3.up * 90;
            if (gun.Right && self.Right && dir == Direction.Right) transform.eulerAngles += Vector3.up * 90;
        }
        else {
            if (dir == Direction.Left) transform.eulerAngles -= Vector3.up * 90;
            if (dir == Direction.Right) transform.eulerAngles += Vector3.up * 90;
        }
    }

    private void Move(Direction dir) {
        if (gun.gameObject.activeInHierarchy) {
            if (gun.Forward && self.Forward && dir == Direction.Forward) transform.position += transform.right;
            if (gun.Back && self.Back && dir == Direction.Back) transform.position -= transform.right;
            if (gun.Left && self.Left && dir == Direction.Left) transform.position += transform.forward;
            if (gun.Right && self.Right && dir == Direction.Right) transform.position -= transform.forward;
        }
        else {
            if (self.Forward && dir == Direction.Forward) transform.position += transform.right;
            if (self.Back && dir == Direction.Back) transform.position -= transform.right;
            if (self.Left && dir == Direction.Left) transform.position += transform.forward;
            if (self.Right && dir == Direction.Right) transform.position -= transform.forward;
        }
    }
}