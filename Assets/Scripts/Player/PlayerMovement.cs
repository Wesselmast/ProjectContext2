using ContextInput;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private bool moveLocal;
    private Animator glowLeft;
    private Animator glowRight;
    private Animator glowTop;
    private Animator glowBottom;

    private WingDetection gun;
    private WingDetection self;
    private Transform door;

    private FMODUnity.StudioEventEmitter ac;

    private void Awake() {
        glowLeft = GameObject.Find("SideGlowLeft").GetComponent<Animator>();
        glowRight = GameObject.Find("SideGlowRight").GetComponent<Animator>();
        glowTop = GameObject.Find("TopGlow").GetComponent<Animator>();
        glowBottom = GameObject.Find("BottomGlow").GetComponent<Animator>();
        door = FindObjectOfType<Door>().transform;
        ac = GetComponent<FMODUnity.StudioEventEmitter>();
        transform.eulerAngles = new Vector3(door.eulerAngles.x, door.eulerAngles.y + 90, door.eulerAngles.z);
        transform.position = door.position;
        WingDetection[] temp = FindObjectsOfType<WingDetection>();
        self = temp[0];
        gun = temp[1];
    }

    private void OnEnable() {
        PlayerInput.Move += Move;
    }

    private void OnDisable() {
        PlayerInput.Move -= Move;
    }

    private void Move(Direction dir) {
        if (moveLocal) {
            switch (dir) {
                case Direction.Forward: CheckHowToMove(gun.LocalForward, self.LocalForward, transform.right); break;
                case Direction.Back: CheckHowToMove(gun.LocalBack, self.LocalBack, -transform.right); break;
                case Direction.Right: CheckHowToMove(gun.LocalRight, self.LocalRight, -transform.forward); break;
                case Direction.Left: CheckHowToMove(gun.LocalLeft, self.LocalLeft, transform.forward); break;
            }
        }
        else {
            switch (dir) {
                case Direction.Forward: CheckHowToMove(gun.Forward, self.Forward, Vector3.forward); break;
                case Direction.Back: CheckHowToMove(gun.Back, self.Back, -Vector3.forward); break;
                case Direction.Right: CheckHowToMove(gun.Right, self.Right, Vector3.right); break;
                case Direction.Left: CheckHowToMove(gun.Left, self.Left, -Vector3.right); break;
            }
        }
    }

    private void CheckHowToMove(bool gun, bool self, Vector3 direction) {
        Vector3 prevPosition = transform.position;
        if (this.gun.gameObject.activeInHierarchy) {
            if (gun && self) transform.position += direction;
        }
        else if (self) transform.position += direction;
        if (prevPosition == transform.position) {
            ac.Play();
            if (direction == transform.right) glowTop.Play("SideGlowNew");
            else if (direction == -transform.right) glowBottom.Play("SideGlowNew");
            else if (direction == -transform.forward) glowRight.Play("SideGlowNew");
            else glowLeft.Play("SideGlowNew");
        }
    }
}