using ContextInput;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
    private WingDetection gun;
    private WingDetection self;

    private void Awake() {
        WingDetection[] temp = FindObjectsOfType<WingDetection>();
        self = temp[0];
        gun = temp[1];
    }

    private void OnEnable() {
        PlayerInput.Rotate += Rotate;
    }

    private void OnDisable() {
        PlayerInput.Rotate -= Rotate;
    }

    private void Rotate(Direction dir) {
        switch (dir) {
            case Direction.Left: CheckHowToRotate(gun.LocalLeft, self.LocalLeft, -Vector3.up * 90); break;
            case Direction.Right: CheckHowToRotate(gun.LocalRight, self.LocalRight, Vector3.up * 90); break;
        }
    }

    private void CheckHowToRotate(bool gun, bool self, Vector3 rotation) {
        if (this.gun.gameObject.activeInHierarchy) {
            if (gun && self) transform.eulerAngles += rotation;
        }
        else transform.eulerAngles += rotation;
    }
}
