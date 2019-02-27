using ContextInput;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
    [SerializeField] private WingDetection gun;
    [SerializeField] private WingDetection self;

    private void OnEnable() {
        PlayerInput.Rotate += Rotate;
    }

    private void OnDisable() {
        PlayerInput.Rotate -= Rotate;
    }

    private void Rotate(Direction dir) {
        if (gun.gameObject.activeInHierarchy) {
            if (gun.LocalLeft && self.LocalLeft && dir == Direction.Left) transform.eulerAngles -= Vector3.up * 90;
            if (gun.LocalRight && self.LocalRight && dir == Direction.Right) transform.eulerAngles += Vector3.up * 90;
        }
        else {
            if (dir == Direction.Left) transform.eulerAngles -= Vector3.up * 90;
            if (dir == Direction.Right) transform.eulerAngles += Vector3.up * 90;
        }
    }
}
