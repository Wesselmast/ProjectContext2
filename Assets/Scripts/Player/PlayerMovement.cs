using ContextInput;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public bool CoroutineRunning = false;

    [SerializeField] private bool moveLocal;
    [SerializeField] private float speed;
    private Animator characterAnimator;
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
        self = GameObject.Find("Col").GetComponent<WingDetection>();
        gun = GameObject.Find("Weapon").GetComponent<WingDetection>();
        characterAnimator = GameObject.Find("Art").GetComponentInChildren<Animator>();
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
        if (!Door.GunGone) {
            if (gun && self && !CoroutineRunning) if (!CoroutineRunning) StartCoroutine(MoveToLocation(direction));
        }
        else if (self) if(!CoroutineRunning) StartCoroutine(MoveToLocation(direction));
        if (prevPosition == transform.position && !CoroutineRunning) {
            try { ac.Play(); }
            catch { }
            if (direction == transform.right) glowTop.Play("SideGlowNew");
            else if (direction == -transform.right) glowBottom.Play("SideGlowNew");
            else if (direction == -transform.forward) glowRight.Play("SideGlowNew");
            else glowLeft.Play("SideGlowNew");
        }
    }

    private IEnumerator MoveToLocation(Vector3 direction) {
        CoroutineRunning = true;
        if (direction == transform.right) characterAnimator.SetBool("doWalkForwards", true);
        else if (direction == -transform.right) characterAnimator.SetBool("doWalkBackwards", true);
        else if (direction == -transform.forward) characterAnimator.SetBool("doWalkRight", true);
        else characterAnimator.SetBool("doWalkLeft", true);
        Vector3 startPos = transform.position;
        float step = (speed / (startPos - (startPos + direction)).magnitude * Time.deltaTime);
        float currentTime = 0;
        while(currentTime <= 1f) {
            currentTime += step;
            transform.position = Vector3.Lerp(startPos, (startPos + direction), currentTime);
            yield return null;
        }
        transform.position = startPos + direction;
        characterAnimator.SetBool("doWalkForwards", false);
        characterAnimator.SetBool("doWalkBackwards", false);
        characterAnimator.SetBool("doWalkRight", false);
        characterAnimator.SetBool("doWalkLeft", false);
        CoroutineRunning = false;
    }
}