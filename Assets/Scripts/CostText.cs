using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = 10 - transform.parent.GetComponent<Slider>().value;
        GetComponent<Text>().text = temp.ToString();
    }
}
