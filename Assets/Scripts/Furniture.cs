using UnityEngine;

public class Furniture : MonoBehaviour
{
    public int cost;
    public string customName;
    public bool isDone = false;

    public void ChangeMaterial(Material mat) {
        transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;
    }
}
