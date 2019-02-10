using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleCrossHandler : MonoBehaviour {

    [SerializeField] private GameObject[] otherCrossGroups;

    private FurnitureCollider[] furCols;

    private void Awake() {
        furCols = GetComponentsInChildren<FurnitureCollider>();
        foreach (var f in furCols) {
            f.gameObject.layer = LayerMask.NameToLayer("Placeable");
        }
    }

    private void Update() {
        foreach (var f in furCols) {
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
    }
}
