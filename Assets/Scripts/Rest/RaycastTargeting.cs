using System.Linq;
using UnityEngine;

public class RaycastTargeting : MonoBehaviour {
    [SerializeField] private Furniture target;
    [SerializeField] private GameObject animatedCross;
    [SerializeField] private GameObject animatedDone;

    public Furniture Target {
        get {
            return target;
        }
        set {
            target = value;
        }
    }

    public GameObject NotDone {
        get {
            return animatedCross;
        }
        set {
            animatedCross = value;
        }
    }
    public GameObject Done {
        get {
            return animatedDone;
        }
        set {
            animatedDone = value;
        }
    }

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
        return children.Any(w => target.name == w.TargetName);
    }
}
