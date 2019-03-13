using UnityEngine;
using UnityEngine.UI;

public class CostText : MonoBehaviour {

    public static float CurrentMaterial { get; set; }

    [SerializeField] private float maxMaterial;
    private Text text;

    private void Awake() {
        text = GetComponent<Text>();
        CurrentMaterial = maxMaterial;
    }

    private void Update() {
        text.text = Mathf.FloorToInt(CurrentMaterial).ToString();
    }
}
