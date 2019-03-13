using UnityEngine;

public class FurnitureCollider : MonoBehaviour {
    private bool isTriggered = false;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") return;
        if (other.gameObject.layer != LayerMask.NameToLayer("Walls") &&
            other.gameObject.layer != LayerMask.NameToLayer("Not Placeable")) return;
        if(other.gameObject.layer == LayerMask.NameToLayer("Not Placeable")) {
            if (gameObject.layer == LayerMask.NameToLayer("Placeable")) return;
            if (gameObject.layer == LayerMask.NameToLayer("Not Placeable")) return;
        }
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other) {
        isTriggered = false;
    }

    public bool GetIsTriggered() {
        return isTriggered;
    }
}
