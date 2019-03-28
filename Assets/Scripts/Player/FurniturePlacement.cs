using ContextInput;
using UnityEngine;

public class FurniturePlacement : MonoBehaviour {
    public GameObject Furniture { get; set; }
    public Material Original { get; set; }
    [SerializeField] private Material blueprintMat;
    [SerializeField] private Material disabledMat;
    [SerializeField] private GameObject placementSprite;

    private Grid grid;
    private FurnitureCollisionManager manager;
    private PlayerMovement movement;

    private void Awake() {
        grid = FindObjectOfType<Grid>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        if (Furniture != null) {
            if (!Furniture.GetComponentInChildren<FurnitureCollisionManager>().AnyColliderTriggered && 
                               CostText.CurrentMaterial >= Furniture.GetComponent<Furniture>().Cost &&
                               !movement.CoroutineRunning) {
                Furniture.GetComponent<Furniture>().ChangeMaterial(blueprintMat);
                if (PlayerInput.Place) {
                    GameObject obj = Instantiate(Furniture, Furniture.transform.position, Furniture.transform.rotation);
                    obj.GetComponent<Furniture>().Spawn(Original);
                    CostText.CurrentMaterial -= obj.GetComponent<Furniture>().Cost;
                    Door.CurrentFurnitures.Add(obj.GetComponent<Furniture>().CustomName);
                    Destroy(Furniture);
                    if (placementSprite == null) return;
                    placementSprite.SetActive(false);
                }
                else if (placementSprite != null) {
                    placementSprite.SetActive(true);
                    return;
                }
            }
            else Furniture.GetComponent<Furniture>().ChangeMaterial(disabledMat);
        }
        if (placementSprite == null) return;
        placementSprite.SetActive(false);
    }
}