using UnityEngine;
using ContextInput;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float walkSpeed, jumpSpeed;

    private Rigidbody rb;

    private void Awake() {
        PlayerInput.OnJump += Jump;
        rb = GetComponent<Rigidbody>();
    }

    private void Jump() {
        rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
    }

    private void Update() {
        transform.Translate(new Vector3(PlayerInput.Horizontal,0, PlayerInput.Vertical) * walkSpeed * Time.deltaTime);
    }
}
