using ContextInput;
using UnityEngine;

public class FurniturePlacement : MonoBehaviour {
    public GameObject Furniture { get; set; }
    public Material Original { get; set; }
    [SerializeField] private Material blueprintMat;
    [SerializeField] private Material disabledMat;

    private Grid grid;
    private FurnitureCollisionManager manager;

    private void Awake() {
        grid = FindObjectOfType<Grid>();
    }

    private void Update() {
        if (Furniture != null) {
            if (!Furniture.GetComponentInChildren<FurnitureCollisionManager>().AnyColliderTriggered) {
                Furniture.GetComponent<Furniture>().ChangeMaterial(blueprintMat);
                if (PlayerInput.Place && CostText.currentMaterial >= Furniture.GetComponent<Furniture>().Cost) {
                    GameObject obj = Instantiate(Furniture, Furniture.transform.position, Furniture.transform.rotation);
                    obj.GetComponent<Furniture>().Spawn(Original);
                    CostText.currentMaterial -= obj.GetComponent<Furniture>().Cost;
                    Door.currentFurnitures.Add(obj.GetComponent<Furniture>().customName);
                    Destroy(Furniture);
                }
            }
            else Furniture.GetComponent<Furniture>().ChangeMaterial(disabledMat);
        }
    }
}