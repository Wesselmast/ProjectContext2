using UnityEngine;

[CreateAssetMenu(fileName = "New Furniture", menuName = "Custom/Furniture")]
public class FurnitureSettings : ScriptableObject {
    [SerializeField] private string customName;
    public string CustomName { get { return customName; } }
    [SerializeField] private int cost;
    public int Cost { get { return cost; } }
    [SerializeField] private Face seeableFace = Face.All;
    public Face TargetFace { get { return seeableFace; } }
    [SerializeField] private GameObject spawnParticlePrefab;
    public GameObject SpawnParticlePrefab { get { return spawnParticlePrefab; } }
    [SerializeField] private GameObject destroyParticlePrefab;
    public GameObject DestroyParticlePrefab { get { return destroyParticlePrefab; } }
}