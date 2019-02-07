using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public int cost;  







    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMaterial(Material mat)
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;
    }
}
