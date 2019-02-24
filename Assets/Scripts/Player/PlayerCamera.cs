using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    [SerializeField] private float damping = 1;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private Transform target;

    private void Awake() {
        target = FindObjectOfType<ContextInput.PlayerInput>().transform;
    }

    private void LateUpdate() {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.eulerAngles.y + 90;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = Vector3.Lerp(transform.position, target.position + rotation * offset, Time.deltaTime * damping);
        transform.LookAt(target);
    }
}