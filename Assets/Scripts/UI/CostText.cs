using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostText : MonoBehaviour {

    [SerializeField] private float maxMaterial;
    public static float currentMaterial;
    private Text text;

    private void Awake() {
        text = GetComponent<Text>();
        currentMaterial = maxMaterial;
    }

    private void Update() {
        text.text = currentMaterial.ToString();
    }
}
