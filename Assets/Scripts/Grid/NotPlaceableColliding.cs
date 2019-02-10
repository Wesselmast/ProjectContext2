using UnityEngine;

public class NotPlaceableColliding : MonoBehaviour {
    [SerializeField] private LayerMask walls;

    private bool isColliding = false;
    private Collider[] cols;

    private void Awake() {
        cols = GetComponentsInChildren<Collider>();
    }

    private void Update() {
        foreach (Collider c in cols) {
            if (Physics.CheckBox(c.bounds.center, c.bounds.extents, c.transform.rotation, walls)) {
                isColliding = true;
                return;
            }
            else {
                isColliding = false;
            }
        }
    }

    public bool GetColliding() {
        return isColliding;
    }

}
