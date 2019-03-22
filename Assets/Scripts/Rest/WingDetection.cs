using UnityEngine;

public class WingDetection : MonoBehaviour {

    [SerializeField] private float rayDistance = 1f;
    [SerializeField] private bool checkWorldPos = false;

    [Header("Checking")]
    [SerializeField] private bool checkLeft = false;
    [SerializeField] private bool checkRight = false;
    [SerializeField] private bool checkForward = false;
    [SerializeField] private bool checkBack = false;

    public bool LocalLeft { get; private set; }
    public bool LocalRight { get; private set; }
    public bool LocalForward { get; private set; }
    public bool LocalBack { get; private set; }
    public bool Left { get; private set; }
    public bool Right { get; private set; }
    public bool Forward { get; private set; }
    public bool Back { get; private set; }

    public string TargetName { get; private set; }
    private LayerMask walls;

    private void Awake() {
        walls = LayerMask.GetMask("Walls");
    }

    private void FixedUpdate() {
        if (checkLeft) LocalLeft = CheckRay(transform.forward);
        if (checkRight) LocalRight = CheckRay(-transform.forward);
        if (checkForward) LocalForward = CheckRay(transform.right);
        if (checkBack) LocalBack = CheckRay(-transform.right);
        if (checkWorldPos) {
            if (checkLeft) Left = CheckRay(Vector3.left);
            if (checkRight) Right = CheckRay(Vector3.right);
            if (checkForward) Forward = CheckRay(Vector3.forward);
            if (checkBack) Back = CheckRay(Vector3.back);
        }
    }

    private int index;

    private bool CheckRay(Vector3 targetPosition) {
        bool isTriggered = true;
        TargetName = string.Empty;
        if (Physics.Raycast(new Ray(transform.position, targetPosition), out RaycastHit hit, rayDistance, walls)) {
            isTriggered = false;
            try {
                Furniture fur = hit.collider.GetComponentInParent<Furniture>();
                TargetName = fur.CheckFaces(hit.normal) ? fur.CustomName : string.Empty;
            }
            catch { }
        }
        return isTriggered;
    }
}