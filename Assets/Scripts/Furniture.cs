using UnityEngine;

public class Furniture : MonoBehaviour
{
    public int cost;
    public string customName;

    [SerializeField] bool isMultipleObject;

    [HideInInspector] public bool spawned;

    private void Start()
    {
        //spawned = false;
    }

    public void Spawn(Material originalMat)
    {
        Debug.Log("Spawned");
        spawned = true;

        ChangeMaterial(originalMat);
        transform.GetChild(1).GetComponent<FurnitureCollisionManager>().SetColliderTrigger(false);
        transform.GetChild(1).GetComponent<FurnitureCollisionManager>().SetColliderLayer("Walls");

        
    }

    public void ChangeMaterial(Material mat)
    {
        if (!isMultipleObject)
            transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;
        else
        {
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material = mat;
            }
        }
    }
}
