using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Material transparentMat;
    private Material originalMat;

    // Start is called before the first frame update
    void Start()
    {
        originalMat = GetComponent<MeshRenderer>().material;
    }

    public void ChangeMaterialToOriginal()
    {
        GetComponent<MeshRenderer>().material = originalMat;
    }


    private void OnTriggerStay(Collider other)
    {
        GetComponent<MeshRenderer>().material = originalMat;

        if (other.CompareTag("FurnitureBlueprint"))
        {
            GetComponent<MeshRenderer>().material = transparentMat;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FurnitureBlueprint"))
        {
            GetComponent<MeshRenderer>().material = originalMat;
        }
    }

}
