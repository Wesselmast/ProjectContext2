using ContextInput;
using UnityEngine;

public class FurniturePlacement : MonoBehaviour {
    [HideInInspector] public GameObject furniture;
    [HideInInspector] public Material originalMat;
    [SerializeField] private Material blueprintMat;
    [SerializeField] private Material disabledMat;

    private Grid grid;
    private FurnitureCollisionManager manager;

    private void Awake() {
        grid = FindObjectOfType<Grid>();
    }

    private void Update() {
        if (furniture != null) {
            if (!furniture.GetComponentInChildren<FurnitureCollisionManager>().GetAnyColliderTriggered()) {
                furniture.GetComponent<Furniture>().ChangeMaterial(blueprintMat);
                if (PlayerInput.Place && CostText.currentMaterial >= furniture.GetComponent<Furniture>().cost) {
                    GameObject obj = Instantiate(furniture, furniture.transform.position, furniture.transform.rotation);
                    obj.GetComponent<Furniture>().Spawn(originalMat);
                    CostText.currentMaterial -= obj.GetComponent<Furniture>().cost;
                    Door.currentFurnitures.Add(obj.GetComponent<Furniture>().customName);
                    Destroy(furniture);
                }
            }
            else furniture.GetComponent<Furniture>().ChangeMaterial(disabledMat);
        }
    }
}