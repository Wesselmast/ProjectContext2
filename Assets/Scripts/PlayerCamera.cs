using ContextInput;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    [SerializeField]
    private float mouseSensitivity = 5.0f;
    [SerializeField]
    private float smoothing = 2.0f;

    private Vector2 smoothV = new Vector2();
    private Vector2 mouseLook = new Vector2();
    private Transform player;

    private void Awake() {
        player = transform.parent;
    }

    private void Update() {
        Vector2 rotation = PlayerInput.MouseRotation;
        rotation = Vector2.Scale(rotation, new Vector2(mouseSensitivity * smoothing, mouseSensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, rotation.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, rotation.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.gameObject.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}