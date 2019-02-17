using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureFX : MonoBehaviour {
    [SerializeField] private GameObject particlePrefab;

    private void Awake() { SpawnParticle(); }
    private void OnDestroy() { SpawnParticle(); }

    private void SpawnParticle() {
        foreach (var c in GetComponentsInChildren<FurnitureCollider>()) {
            //if (c.gameObject.layer == LayerMask.GetMask("Walls")) {
                GameObject particle = Instantiate(particlePrefab, c.transform.position, c.transform.rotation);
                Destroy(particle, 1f);
            //}
        }
    }
}