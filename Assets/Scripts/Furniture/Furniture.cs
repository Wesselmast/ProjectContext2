using UnityEngine;

public class Furniture : MonoBehaviour {
    private enum Face {
        Front,
        Back,
        Left,
        Right,
        All
    }

    public int Cost;
    public string customName;

    [SerializeField] private bool isMultipleObject = false;
    [SerializeField] private Face targetFace = Face.All;

    [HideInInspector] public bool spawned = false;

    public void Spawn(Material originalMat) {
        ChangeMaterial(originalMat);
        var fcm = transform.GetChild(1).GetComponent<FurnitureCollisionManager>();
        fcm.SetColliderLayer("Walls");
        fcm.SetCrosses("Not Placeable");
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

    public bool CheckFaces(Vector3 normal) {
        if (targetFace == Face.Front && normal == -transform.right) return true;
        if (targetFace == Face.Back && normal == transform.right) return true;
        if (targetFace == Face.Left && normal == -transform.forward) return true;
        if (targetFace == Face.Right && normal == transform.forward) return true;
        if (targetFace == Face.All) return true;
        return false;
    }
}
