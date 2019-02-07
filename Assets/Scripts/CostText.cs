using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostText : MonoBehaviour {

    [SerializeField] private float maxMaterial;
    private Slider slider;
    private static float currentMaterial;
    private Text text;

    private void Awake() {
        slider = transform.parent.GetComponent<Slider>();
        text = GetComponent<Text>();
    }

    private void Update() {
        currentMaterial = maxMaterial - slider.value;
        text.text = currentMaterial.ToString();
    }

    public static float GetCurrentMaterial() {
        return currentMaterial;
    }
}
