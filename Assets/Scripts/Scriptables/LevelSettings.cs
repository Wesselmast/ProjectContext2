using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Custom/Level")]
public class LevelSettings : ScriptableObject {
    [SerializeField] private GameObject[] requiredFurnitures;
    public List<string> RequiredFurnitures {
        get {
            List<string> temp = new List<string>();
            foreach (var rf in requiredFurnitures) {
                try { temp.Add(rf.GetComponent<Furniture>().CustomName); }
                catch { }
            }
            return temp;
        }
    }
}