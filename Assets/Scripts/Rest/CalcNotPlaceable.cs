using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcNotPlaceable : MonoBehaviour {

    [SerializeField] private NotPlaceableColliding[] notPlaceable;

    private void Update() {
        for (int i = 0; i < notPlaceable.Length; i++) {
            if (notPlaceable[i].IsColliding) {
                foreach (var n in notPlaceable) {
                    n.gameObject.SetActive(false);
                }
            }
        }
    }
}
