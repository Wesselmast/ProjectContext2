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
        if (placement.furniture != null) Destroy(placement.furniture);
        placement.furniture = Instantiate(furniturePrefab, spawnpoint.position, spawnpoint.rotation);
        placement.furniture.transform.SetParent(spawnpoint);
        placement.furniture.GetComponentInChildren<FurnitureCollisionManager>().SetColliderLayer("Default");
        placement.originalMat = originalMaterial;
        for (int i = 0; i < walls.Length; i++) {
            walls[i].ChangeMaterialToOriginal();
        }
    }
}
