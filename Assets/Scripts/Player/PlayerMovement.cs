using ContextInput;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private WingDetection gun;
    [SerializeField] private WingDetection self;
    [SerializeField] private bool moveLocal;

    private Grid grid;
    private Transform door;

    private void Awake() {
        door = FindObjectOfType<Door>().transform;
        transform.eulerAngles = new Vector3(door.eulerAngles.x, door.eulerAngles.y + 90, door.eulerAngles.z);
        transform.position = door.position;
        grid = FindObjectOfType<Grid>();
    }

    private void OnEnable() {
        PlayerInput.Rotate += Rotate;
        PlayerInput.Move += Move;
    }

    private void OnDisable() {
        PlayerInput.Rotate -= Rotate;
        PlayerInput.Move -= Move;
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

    private void Move(Direction dir) {
        if (moveLocal) {
            if (gun.gameObject.activeInHierarchy) {
                if (gun.LocalForward && self.LocalForward && dir == Direction.Forward) transform.position += transform.right;
                if (gun.LocalBack && self.LocalBack && dir == Direction.Back) transform.position -= transform.right;
                if (gun.LocalRight && self.LocalRight && dir == Direction.Right) transform.position -= transform.forward;
                if (gun.LocalLeft && self.LocalLeft && dir == Direction.Left) transform.position += transform.forward;
            }
            else {
                if (self.LocalForward && dir == Direction.Forward) transform.position += transform.right;
                if (self.LocalBack && dir == Direction.Back) transform.position -= transform.right;
                if (self.LocalRight && dir == Direction.Right) transform.position -= transform.forward;
                if (self.LocalLeft && dir == Direction.Left) transform.position += transform.forward;
            }
        }
        else {
            if (gun.gameObject.activeInHierarchy) {
                if (gun.Forward && self.Forward && dir == Direction.Forward) transform.position += Vector3.forward;
                if (gun.Back && self.Back && dir == Direction.Back) transform.position -= Vector3.forward;
                if (gun.Right && self.Right && dir == Direction.Right) transform.position += Vector3.right;
                if (gun.Left && self.Left && dir == Direction.Left) transform.position -= Vector3.right;
            }
            else {
                if (self.Forward && dir == Direction.Forward) transform.position += Vector3.forward;
                if (self.Back && dir == Direction.Back) transform.position -= Vector3.forward;
                if (self.Right && dir == Direction.Right) transform.position += Vector3.right;
                if (self.Left && dir == Direction.Left) transform.position -= Vector3.right;
            }
        }
    }
}