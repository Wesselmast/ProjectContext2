using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler {
    [SerializeField] private Animator anim;
    public Button m_YourFirstButton;
    private int Pressed = 0;

    public void OnPointerEnter(PointerEventData eventData) 
    {
        anim.SetBool("Highlighted2", true);


           
    }
    void Start()
    {
        m_YourFirstButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        anim.SetBool("Pressed", true);
        Pressed++;

        if(Pressed == 2)
        {
            anim.SetBool("Pressed", false);
            Pressed = 0;
        }
    }

}
