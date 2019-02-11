using UnityEngine;

public class WingDetection : MonoBehaviour {

    [SerializeField] private float rayDistance = 1f;

    [Header("Checking")]
    [SerializeField] private bool checkLeft = true;
    [SerializeField] private bool checkRight = true;
    [SerializeField] private bool checkForward = true;
    [SerializeField] private bool checkBack = true;

    public bool Left { get; private set; }
    public bool Right { get; private set; }
    public bool Forward { get; private set; }
    public bool Back { get; private set; }

    private string targetName;
    private LayerMask walls;

    private void Awake() {
        walls = LayerMask.GetMask("Walls");
    }

    private void Update() {
        if (checkLeft) Left = CheckRay(transform.forward);
        if (checkRight) Right = CheckRay(-transform.forward);
        if (checkForward) Forward = CheckRay(transform.right);
        if (checkBack) Back = CheckRay(-transform.right);
    }

    private bool CheckRay(Vector3 targetPosition) {
        bool isTriggered = true;
        targetName = string.Empty;
        if (Physics.Raycast(new Ray(transform.position, targetPosition), out RaycastHit hit, rayDistance, walls)) {
            isTriggered = false;
            try {
                targetName = hit.collider.GetComponentInParent<Furniture>().customName;
            }
            catch { }
        }
        return isTriggered;
    }

    public string TargetName() {
        return targetName;
    }
}