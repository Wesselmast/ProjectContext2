using UnityEngine;
using UnityEngine.UI;

public class CostText : MonoBehaviour {

    [SerializeField] private float maxMaterial;
    public static float CurrentMaterial { get; set; }
    private Text text;

    private void Awake() {
        text = GetComponent<Text>();
        CurrentMaterial = maxMaterial;
    }

    private void Update() {
        text.text = CurrentMaterial.ToString("F1");
    }
}
