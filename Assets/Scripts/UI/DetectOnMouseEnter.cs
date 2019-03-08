using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectOnMouseEnter : MonoBehaviour, IPointerEnterHandler {

    [SerializeField] private Animator anim;

    public void OnPointerEnter(PointerEventData eventData) {
        anim.SetBool("IsEntered", true);
    }
}
