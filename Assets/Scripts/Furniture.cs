using UnityEngine;

public class Furniture : MonoBehaviour {
    public int cost;
    public string customName;

    [SerializeField] private bool isMultipleObject = false;

    [HideInInspector] public bool spawned = false;

    public void Spawn(Material originalMat) {
        ChangeMaterial(originalMat);
        var fcm = transform.GetChild(1).GetComponent<FurnitureCollisionManager>();
        fcm.SetColliderLayer("Walls");
        fcm.SetColliderTag("Furniture");
        spawned = true;
    }

    public void ChangeMaterial(Material mat) {
        if (!isMultipleObject) transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;
        else {
            for (int i = 0; i < transform.GetChild(0).childCount; i++) {
                transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material = mat;
            }
        }
    }
}
