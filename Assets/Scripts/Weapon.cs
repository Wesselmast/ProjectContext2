using ContextInput;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Camera cam;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float materialCost;

    private void Awake() {
        cam = Camera.main; 
        PlayerInput.OnShoot += Shoot;
    }

    private void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out hit)) {
            if (hit.collider.tag == "Furniture") {
                Destroy(hit.collider.gameObject);
                MaterialManager.AddMaterial(materialCost);
            }
            else if (hit.collider.tag == "FurniturePlace" && MaterialManager.GetMaterial() - materialCost >= 0) {
                Instantiate(bulletPrefab, hit.transform.position, hit.transform.rotation);
                MaterialManager.RemoveMaterial(materialCost);
            }
        }
    }
}
