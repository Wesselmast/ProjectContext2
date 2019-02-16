using UnityEngine;

public enum Face {
    Front,
    Back,
    Left,
    Right,
    All
}

public class Furniture : MonoBehaviour {
    [SerializeField] private FurnitureSettings settings;
    [HideInInspector] public bool Spawned = false;

    public int Cost { get { return settings.Cost; } }
    public string CustomName { get { return settings.CustomName; } }

    public void Spawn(Material originalMat) {
        ChangeMaterial(originalMat);
        var fcm = transform.GetChild(1).GetComponent<FurnitureCollisionManager>();
        fcm.SetColliderLayer("Walls");
        fcm.SetCrosses("Not Placeable");
        fcm.SetColliderTag("Furniture");
        Spawned = true;
    }

    public void ChangeMaterial(Material mat) {
        foreach (var mr in transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()) {
            mr.material = mat;
        }
    }

    public bool CheckFaces(Vector3 normal) {
        if (settings.TargetFace == Face.Front && normal == -transform.right) return true;
        if (settings.TargetFace == Face.Back && normal == transform.right) return true;
        if (settings.TargetFace == Face.Left && normal == -transform.forward) return true;
        if (settings.TargetFace == Face.Right && normal == transform.forward) return true;
        if (settings.TargetFace == Face.All) return true;
        return false;
    }
}
