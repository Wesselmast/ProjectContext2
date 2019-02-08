using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] string detectingObjectName;

    private List<GameObject> collidedObjects;

    public bool detected;

    // Start is called before the first frame update
    void Start()
    {
        detectingObjectName += "Collider";
    }

    // Update is called once per frame
    void Update()
    {
        GameObject temp = new GameObject();
        temp.transform.position = new Vector3(999, 999, 999);

        for (int i = 0; i < collidedObjects.Capacity; i++)
        {
            if (GetDistanceToThisObject(temp.transform.position) > GetDistanceToThisObject(collidedObjects[i].transform.position))
            {
                temp = collidedObjects[i];
            }
            
        }

        if (temp.name == detectingObjectName)
        {

        }

        collidedObjects.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        collidedObjects.Add(other.gameObject);
    }

    private float GetDistanceToThisObject(Vector3 pos)
    {
        float xDis = Mathf.Abs(transform.position.x - pos.x);
        float zDis = Mathf.Abs(transform.position.z - pos.z);

        return xDis + zDis;
    }
}
