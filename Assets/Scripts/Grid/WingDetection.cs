using UnityEngine;

public class WingDetection : MonoBehaviour {
    [SerializeField] private LayerMask walls;

    public bool Left { get; private set; }
    public bool Right { get; private set; }
    public bool Forward { get; private set; }
    public bool Back { get; private set; }
    public bool LocalLeft { get; private set; }
    public bool LocalRight { get; private set; }

    private void Update() {
        Left = !Physics.Raycast(transform.position, Vector3.left, 1f, walls);
        Right = !Physics.Raycast(transform.position, Vector3.right, 1f, walls);
        Forward = !Physics.Raycast(transform.position, Vector3.forward, 1f, walls);
        Back = !Physics.Raycast(transform.position, Vector3.back, 1f, walls);
        LocalLeft = !Physics.Raycast(transform.position, transform.forward, 1f, walls);
        LocalRight = !Physics.Raycast(transform.position, -transform.forward, 1f, walls);
    }
}