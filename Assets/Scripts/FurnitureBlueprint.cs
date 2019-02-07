using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureBlueprint : MonoBehaviour
{
    public int cost;


    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(1).GetComponent<Text>().text = cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
