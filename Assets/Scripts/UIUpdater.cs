using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {

    private Slider slider;

    private void Start() {
        slider = GetComponent<Slider>();
    }

    private void Update() {
        slider.value = MaterialManager.GetMaterial();
    }
}
