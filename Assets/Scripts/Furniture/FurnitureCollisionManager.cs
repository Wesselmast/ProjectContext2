using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureCollisionManager : MonoBehaviour {
    private bool anyColliderTriggered = true;
    public bool AnyColliderTriggered { get { return anyColliderTriggered; } }

    private FurnitureCollider[] colliders;

    private void Awake() {
        colliders = GetComponentsInChildren<FurnitureCollider>();
    }

    private void Update() {
        foreach (var c in colliders) {
            if (c.GetIsTriggered() && c.gameObject.layer != LayerMask.NameToLayer("Placeable")) {
                anyColliderTriggered = true;
                return;
            }
            anyColliderTriggered = false;
        }
    }

    public void SetColliderLayer(string layerName) {
        foreach (var c in colliders) {
            if (c.gameObject.layer != LayerMask.NameToLayer("Not Placeable") &&
                c.gameObject.layer != LayerMask.NameToLayer("Placeable")) {
                c.gameObject.layer = LayerMask.NameToLayer(layerName);
            }
        }
    }

    public void SetCrosses(string layerName) {
        foreach (var c in colliders) {
            if (c.gameObject.layer == LayerMask.NameToLayer("Placeable")) {
                c.gameObject.layer = LayerMask.NameToLayer(layerName);
            }
        }
    }

    public void SetColliderTag(string tag) {
        foreach (var c in colliders) {
            c.gameObject.tag = tag;
        }
    }
}
