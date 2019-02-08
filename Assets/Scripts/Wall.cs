using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Material transparentMat;
    private Material originaMat;

    // Start is called before the first frame update
    void Start()
    {
        originaMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FurnitureBlueprint"))
        {
            GetComponent<MeshRenderer>().material = transparentMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FurnitureBlueprint"))
        {
            GetComponent<MeshRenderer>().material = originaMat;
        }
    }

}
