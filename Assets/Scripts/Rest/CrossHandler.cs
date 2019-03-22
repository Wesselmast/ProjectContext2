using System.Linq;
using UnityEngine;

public class CrossHandler : MonoBehaviour {
    private CrossHandler[] otherCrossGroups;
    private FurnitureCollider[] furCols;
    private Furniture furniture;

    private void Awake() {
        furCols = GetComponentsInChildren<FurnitureCollider>();
        furniture = GetComponentInParent<Furniture>();
        foreach (var f in furCols) {
            f.gameObject.layer = LayerMask.NameToLayer("Placeable");
        }
        otherCrossGroups = transform.parent.GetComponentsInChildren<CrossHandler>().
                                   Where(c => c.gameObject != gameObject).ToArray();
    }

    private void Update() {
        foreach (var f in furCols) {
            if (otherCrossGroups.Length > 0) {
                foreach (var oc in otherCrossGroups) {
                    foreach (var f2 in oc.GetComponentsInChildren<FurnitureCollider>()) {
                        f2.gameObject.layer = LayerMask.NameToLayer("Placeable");
                    }
                }
            }
            else {
                f.gameObject.layer = LayerMask.NameToLayer("Not Placeable");
            }
        }
    }
}
