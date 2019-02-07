using UnityEngine;
using UnityEngine.UI;

public class FurnitureBlueprint : MonoBehaviour {
    [SerializeField]
    private float cost;

    void Start() {
        transform.GetChild(1).GetComponent<Text>().text = cost.ToString();
    }
}