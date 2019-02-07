using ContextInput;
using UnityEngine;
using UnityEngine.UI;

public class FurniturePlacement : MonoBehaviour
{

    [SerializeField] private Slider costBar;

    [SerializeField] private GameObject furniturePrefab;
    //[SerializeField] private Vector3 placementOffset;

    private Material originalMat;
    [SerializeField] private Material blueprintMat;
    [SerializeField] private Material disabledMat;

    private Transform furnitureStructureTrans;

    private Grid grid;
    private Camera cam;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        cam = Camera.main;
        furnitureStructureTrans = transform.GetChild(0).GetChild(0).GetChild(0);
        //PlayerInput.OnLeftClick += Place;
    }

    private void Update()
    {
        if (furniturePrefab != null)
        {
            if (!furniturePrefab.GetComponent<Furniture>().GetTriggered())
            {
                furniturePrefab.GetComponent<MeshRenderer>().material = blueprintMat;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject obj = Instantiate(furniturePrefab, grid.GetGridPoint(furniturePrefab.transform.position), furniturePrefab.transform.rotation);
                    obj.GetComponent<MeshRenderer>().material = originalMat;
                    obj.GetComponent<Collider>().isTrigger = false;
                    Destroy(furniturePrefab);
                }
            }
            else
            {
                furniturePrefab.GetComponent<MeshRenderer>().material = disabledMat;
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
        Debug.Log("Blueprints position : " + furnitureStructureTrans.position);
        furniturePrefab = Instantiate(obj, furnitureStructureTrans.position, furnitureStructureTrans.rotation);
        furniturePrefab.transform.SetParent(transform.GetChild(0).GetChild(0));
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