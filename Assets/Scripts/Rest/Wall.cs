using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    [SerializeField] private Material mat;
    private MeshRenderer r;
    private Material original;

    void Start() {
        r = GetComponent<MeshRenderer>();
        original = r.material;
    }

    public void ChangeMaterialToOriginal() {
        r.material = original;
    }


    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("FurnitureBlueprint")) {
            r.material = mat;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("FurnitureBlueprint")) {
            r.material = original;
        }
    }

}
