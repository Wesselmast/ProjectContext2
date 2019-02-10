using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastTargeting : MonoBehaviour {
    [SerializeField] private Furniture target;

    [SerializeField] private GameObject animatedCross, animatedDone;

    private WingDetection[] children;

    private void Awake() {
        animatedDone.SetActive(false);
        children = GetComponentsInChildren<WingDetection>();
    }

    private void Update() {
        if (ObjectIsTouching()) {
            animatedCross.SetActive(false);
            animatedDone.SetActive(true);
        }
        else {
            animatedCross.SetActive(true);
            animatedDone.SetActive(false);
        }
    }

    public bool ObjectIsTouching() {
        return children.Any(w => w.TargetName() == target.name);
    }
}
