using ContextInput;
using UnityEngine;

public class FurnitureRemoving : MonoBehaviour {
    [SerializeField][Range(0,1)] private float giveBackPercentage = .5f;
    private FurniturePlacement placement;
    private Wall[] walls;

    private void Awake() {
        placement = GetComponentInParent<FurniturePlacement>();
        walls = FindObjectsOfType<Wall>();
    }

    private void OnEnable() {
        PlayerInput.Remove += Remove;
    }

    private void OnDisable() {
        PlayerInput.Remove -= Remove;
    }

    private void Remove() {
        if (Physics.Raycast(new Ray(transform.position, transform.right), out RaycastHit hit, 1, LayerMask.GetMask("Walls"))) {
            try {
                Furniture furniture = hit.collider.GetComponentInParent<Furniture>();
                furniture.SpawnParticle(furniture.Settings.DestroyParticlePrefab);
                CostText.CurrentMaterial += furniture.Cost * giveBackPercentage;
                Door.CurrentFurnitures.Remove(furniture.CustomName);
                Destroy(placement.Furniture);
                for (int i = 0; i < walls.Length; i++) walls[i].ChangeMaterialToOriginal();
                Destroy(furniture.gameObject);
            }
            catch { }
        }
    }
}
