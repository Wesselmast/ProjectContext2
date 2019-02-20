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
            if (!furniture.Spawned) {
                if (otherCrossGroups.Length > 0) {
                    if (f.GetIsTriggered()) {
                        foreach (var oc in otherCrossGroups) {
                            foreach (var f1 in oc.GetComponentsInChildren<FurnitureCollider>()) {
                                f1.gameObject.layer = LayerMask.NameToLayer("Not Placeable");
                            }
                        }
                    }
                    else {
                        foreach (var oc in otherCrossGroups) {
                            foreach (var f2 in oc.GetComponentsInChildren<FurnitureCollider>()) {
                                f2.gameObject.layer = LayerMask.NameToLayer("Placeable");
                            }
                        }
                    }
                }
                else {
                    f.gameObject.layer = LayerMask.NameToLayer("Not Placeable");
                }
            }
            else {
                f.gameObject.layer = LayerMask.NameToLayer("Not Placeable");
            }

        }
    }
}
