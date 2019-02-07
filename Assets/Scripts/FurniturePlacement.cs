using ContextInput;
using UnityEngine;
using UnityEngine.UI;

public class FurniturePlacement : MonoBehaviour
{

    [SerializeField] private Slider costBar;

    private GameObject furniturePrefab;
    //[SerializeField] private Vector3 placementOffset;

    private Material originalMat;
    [SerializeField] private Material blueprintMat;
    [SerializeField] private Material disabledMat;

    private Transform furnitureStructureTrans;

    private Grid grid;
    private Camera cam;

    private void Awake() {
        grid = FindObjectOfType<Grid>();
        cam = Camera.main;
        furnitureStructureTrans = transform.GetChild(0).GetChild(0).GetChild(0);
    }

    private void Update()
    { 
        if (furniturePrefab != null)
        {
            if (!furniturePrefab.transform.GetChild(1).GetComponent<FurnitureCollisionManager>().GetAnyColliderTriggered())
            {
                Debug.Log("Blue");
                furniturePrefab.GetComponent<Furniture>().ChangeMaterial(blueprintMat);
                if (Input.GetKeyDown(KeyCode.P) && CostText.GetCurrentMaterial() >= furniturePrefab.GetComponent<Furniture>().cost)
                {
                    GameObject obj = Instantiate(furniturePrefab, furniturePrefab.transform.position, furniturePrefab.transform.rotation);
                    obj.GetComponent<Furniture>().ChangeMaterial(originalMat);
                    obj.transform.GetChild(1).GetComponent<FurnitureCollisionManager>().SetColliderTrigger(false);
                    obj.transform.GetChild(1).GetComponent<FurnitureCollisionManager>().SetColliderLayer("Walls");
                    costBar.value += obj.GetComponent<Furniture>().cost;
                    Door.currentFurnitures.Add(obj.GetComponent<Furniture>().customName);

                    Destroy(furniturePrefab);
                }
            }
            else
            {
                Debug.Log("Red");
                furniturePrefab.GetComponent<Furniture>().ChangeMaterial(disabledMat);
            }
        }
    }

    private void Place()
    {
        //RaycastHit hitInfo;
        //if (Physics.Raycast(cam.ScreenPointToRay(PlayerInput.MousePosition), out hitInfo)) {
        //    if (hitInfo.transform == grid.transform) {
        //        GameObject obj = Instantiate(furniturePrefab, grid.GetGridPoint(hitInfo.point) + placementOffset, Quaternion.identity);
        //        obj.GetComponent<Collider>().isTrigger = false;
        //        costBar.value += furniturePrefab.GetComponent<Furniture>().cost;
        //    }
        //    else if (hitInfo.collider.tag == "Furniture") {
        //        costBar.value -= furniturePrefab.GetComponent<Furniture>().cost / 2;

        //        Destroy(hitInfo.collider.gameObject);
        //    }
        //}
    }

    public void LoadFurnitureFromMenu(GameObject obj)
    {
        Destroy(furniturePrefab);

        furniturePrefab = Instantiate(obj, furnitureStructureTrans.position, furnitureStructureTrans.rotation);
        furniturePrefab.transform.SetParent(transform.GetChild(0).GetChild(0).GetChild(0));
        furniturePrefab.transform.GetChild(1).GetComponent<FurnitureCollisionManager>().SetColliderLayer("Default");
        //furniturePrefab.transform.position = obj.GetComponent<Furniture>().offset;
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