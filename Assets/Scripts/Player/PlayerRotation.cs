using ContextInput;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
    private Animator glowLeft;
    private Animator glowRight;

    private WingDetection gun;
    private WingDetection self;

    private FMODUnity.StudioEventEmitter ac;

    private void Awake() {
        glowLeft = GameObject.Find("SideGlowLeft").GetComponent<Animator>();
        glowRight = GameObject.Find("SideGlowRight").GetComponent<Animator>();
        try { ac = GetComponent<FMODUnity.StudioEventEmitter>(); }
        catch { }
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
        Vector3 prevEulers = transform.eulerAngles;
        if (!Door.GunGone) {
            if (gun && self) transform.eulerAngles += rotation;
        }
        else transform.eulerAngles += rotation;
        if (prevEulers == transform.eulerAngles) {
            try { ac.Play(); }
            catch { }
            if (rotation == Vector3.up * 90) glowRight.Play("SideGlowNew");
            else glowLeft.Play("SideGlowNew");
        }
    }
}
