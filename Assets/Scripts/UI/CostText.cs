using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostText : MonoBehaviour {

    public static float CurrentMaterial { get; set; }

    [SerializeField] private float maxMaterial;
    private TextMeshPro text;

    private void Awake() {
        text = GetComponent<TextMeshPro>();
        CurrentMaterial = maxMaterial;
    }

    private void Update() {
        text.text = Mathf.FloorToInt(CurrentMaterial).ToString();
    }
}
