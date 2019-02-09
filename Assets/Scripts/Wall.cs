using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    private MeshRenderer r;

    // Start is called before the first frame update
    void Start() {
        r = GetComponent<MeshRenderer>();
    }

    public void ChangeMaterialToOriginal() {
        r.enabled = true;
    }


    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("FurnitureBlueprint")) {
            r.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("FurnitureBlueprint")) {
            r.enabled = true;
        }
    }

}
