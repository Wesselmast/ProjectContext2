using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public int cost;

    private bool isTriggered;

    public Vector3 spawnOffSet;

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;

        if (spawnOffSet == Vector3.zero)
            spawnOffSet = new Vector3(1, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground")) return;
        Debug.Log("TriggerEnter with " + other.tag);
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground")) return;

        isTriggered = false;
    }

    public bool GetTriggered()
    {
        return isTriggered;
    }
}
