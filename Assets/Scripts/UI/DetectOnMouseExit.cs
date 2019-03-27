using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectOnMouseExit : MonoBehaviour, IPointerEnterHandler
{

    [SerializeField] private Animator anim;

    [SerializeField] private Animator[] buttons;
    [SerializeField] private Animator[] buttonsShadow;


    [SerializeField] private Animator anim_ButtonHelp;
    [SerializeField] private Animator anim_ButtonShadowHelp;

    [SerializeField] private Animator anim_ButtonRetry;
    [SerializeField] private Animator anim_ButtonShadowRetry;

    [SerializeField] private Animator anim_Scrollbar;
    


    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetBool("IsEntered", false);
            buttonsShadow[i].SetBool("IsEntered", false);
        }

        anim.SetBool("IsEntered", false);

        anim_ButtonHelp.SetBool("IsEntered", false);
        anim_ButtonShadowHelp.SetBool("IsEntered", false);

        anim_ButtonRetry.SetBool("IsEntered", false);
        anim_ButtonShadowRetry.SetBool("IsEntered", false);

        anim_Scrollbar.SetBool("IsEntered2", false);
    }
}


