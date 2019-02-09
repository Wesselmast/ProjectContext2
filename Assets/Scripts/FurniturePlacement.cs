using ContextInput;
using UnityEngine;
using UnityEngine.UI;

public class FurniturePlacement : MonoBehaviour
{

    private GameObject furniture;

    private Material originalMat;
    [SerializeField] private Material blueprintMat;
    [SerializeField] private Material disabledMat;

    private Transform furnitureStructureTrans;

    private Wall[] walls;
    private Grid grid;
    private Camera cam;

    private void Awake() {
        walls = FindObjectsOfType<Wall>(); 
        grid = FindObjectOfType<Grid>();
        cam = Camera.main;
        furnitureStructureTrans = transform.GetChild(0).GetChild(0).GetChild(0);
    }

    private void Update() {
        if (furniture != null) {
            if (!furniture.transform.GetChild(1).GetComponent<FurnitureCollisionManager>().GetAnyColliderTriggered()) {
                furniture.GetComponent<Furniture>().ChangeMaterial(blueprintMat);
                if (Input.GetKeyDown(KeyCode.Space) && CostText.currentMaterial >= furniture.GetComponent<Furniture>().cost) {
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

    public void LoadFurnitureFromMenu(GameObject obj)
    {
        Destroy(furniture);

        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].ChangeMaterialToOriginal();
        }

        furniture = Instantiate(obj, furnitureStructureTrans.position, furnitureStructureTrans.rotation);
        furniture.transform.SetParent(transform.GetChild(0).GetChild(0).GetChild(0));
        furniture.transform.GetChild(1).GetComponent<FurnitureCollisionManager>().SetColliderLayer("Default");
    }

    public void LoadOriginalMaterialFromMenu(Material mat)
    {
        originalMat = mat;
    }

    //public void LoadOriginalFromMenu(GameObject obj)
    //{
    //    furniturePrefab = obj;
    //}
}