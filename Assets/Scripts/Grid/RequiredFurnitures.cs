using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiredFurnitures : MonoBehaviour {
    [SerializeField] private Furniture[] requiredFurnitures;

    public Furniture[] GetRequiredFurnitures() {
        return requiredFurnitures;
    }
}
