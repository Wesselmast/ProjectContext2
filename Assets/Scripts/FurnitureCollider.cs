using UnityEngine;

public class FurnitureCollider : MonoBehaviour {
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Walls")) return;
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Walls")) return;
        isTriggered = false;
    }

    public bool GetIsTriggered() {
        return isTriggered;
    }
}
