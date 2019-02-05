using UnityEngine;

public class MaterialManager : MonoBehaviour {

    [SerializeField] private float maxMaterial;
    private static float material;

    private void Awake() {
        material = maxMaterial;
    }

    public static void RemoveMaterial(float amt) { material -= amt; }
    public static void AddMaterial(float amt) { material += amt; }
    public static float GetMaterial() { return material; }
}
