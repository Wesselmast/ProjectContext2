using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectOnMouseEnterPopUp : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Animator anim;

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("Highlighted2", false);
    }
}
