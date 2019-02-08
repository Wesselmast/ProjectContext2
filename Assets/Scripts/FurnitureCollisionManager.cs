using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureCollisionManager : MonoBehaviour
{
    private bool anyColliderTriggered;

    // Start is called before the first frame update
    void Start()
    {
        anyColliderTriggered = false;

    }

    private void Update()
    {
        anyColliderTriggered = false;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<FurnitureCollider>().GetIsTriggered())
            {
                anyColliderTriggered = true;
                return;
            }
        }
    }


    public bool GetAnyColliderTriggered()
    {
        return anyColliderTriggered;
    }

    public void SetColliderTrigger(bool triggered)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Collider>().isTrigger = triggered;
        }
    }

    public void SetColliderLayer(string layerName)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer(layerName);
            
        }
    }

    public void SetColliderTag(string tag)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.tag = tag;

        }
    }
}
