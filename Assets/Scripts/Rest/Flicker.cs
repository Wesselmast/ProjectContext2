using UnityEngine;

public class Flicker : MonoBehaviour {
    [SerializeField] private Material on, off;
    private float elapsed;
    private MeshRenderer meshRenderer;
    private bool onSwitch = true;

    private void Start() {
        elapsed = Random.Range(2, 8);
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() {
        if (elapsed < 0) {
            onSwitch = !onSwitch;
            if (onSwitch) {
                meshRenderer.material = on;
                elapsed = Random.Range(.1f, 7.5f);
            }
            else {
                meshRenderer.material = off;
                elapsed = Random.Range(.03f, .12f);
            }
            
        }
        else elapsed -= Time.deltaTime;
    }
}
