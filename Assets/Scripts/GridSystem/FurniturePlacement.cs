using ContextInput;
using UnityEngine;

public class FurniturePlacement : MonoBehaviour {

    [SerializeField] private GameObject furniturePrefab;
    [SerializeField] private Vector3 placementOffset;

    private Grid grid;
    private Camera cam;

    private void Awake() {
        grid = FindObjectOfType<Grid>();
        cam = Camera.main;
        PlayerInput.OnLeftClick += Place;
    }

    private void Place() {
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.ScreenPointToRay(PlayerInput.MousePosition), out hitInfo)) {
            if (hitInfo.transform == grid.transform) {
                Instantiate(furniturePrefab, grid.GetGridPoint(hitInfo.point) + placementOffset, Quaternion.identity);
            }
            else if (hitInfo.collider.tag == "Furniture") {
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }
}