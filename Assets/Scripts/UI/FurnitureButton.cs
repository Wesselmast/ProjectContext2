using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FurnitureButton : MonoBehaviour {


    [SerializeField] private GameObject furniturePrefab;
    [SerializeField] private Material originalMaterial;
    private Button button;
    private FurniturePlacement placement;
    private Wall[] walls;
    private Transform spawnpoint;

    private void Awake() {
        spawnpoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        button = GetComponent<Button>();
        walls = FindObjectsOfType<Wall>();
        placement = FindObjectOfType<FurniturePlacement>();
        button.onClick.AddListener(Place);
    }


    private void Place() {
        if (placement.Furniture != null) Destroy(placement.Furniture);
        placement.Furniture = Instantiate(furniturePrefab, spawnpoint.position, spawnpoint.rotation);
        placement.Furniture.transform.SetParent(spawnpoint);
        placement.Furniture.GetComponentInChildren<FurnitureCollisionManager>().SetColliderLayer("Default");
        placement.Original = originalMaterial;
        for (int i = 0; i < walls.Length; i++) {
            walls[i].ChangeMaterialToOriginal();
        }
    }
}
