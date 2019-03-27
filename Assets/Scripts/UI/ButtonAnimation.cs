using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler {
    [SerializeField] private Animator anim;

    public Button m_YourFirstButton;
    private int i = 0;
    


    public void OnPointerEnter(PointerEventData eventData) 
    {
        anim.SetBool("Normal", false);

        if (gameObject.transform.parent.name == "Test_Button")
        {
            anim.SetTrigger("Highlighted");
        }
        else if (gameObject.transform.name == "Button_Help_2.0 Test")
        {
            anim.SetTrigger("HighlightedHelp");
        }
        else if (gameObject.transform.name == "Button_Retry_2.0")
        {
            anim.SetTrigger("HighlightedRetry");
        }
        else
        {
            for (int i = 0; i < 22; i++)
            {
                if (gameObject.transform.parent.name == "Test_Button (" + i + ")")
                {
                    if (i == 1)
                    {
                        anim.SetTrigger("Highlighted1");
                    }
                    else if (i == 2)
                    {
                        anim.SetTrigger("Highlighted2");
                    }
                    else if (i == 3)
                    {
                        anim.SetTrigger("Highlighted3");
                    }
                    else if (i == 4)
                    {
                        anim.SetTrigger("Highlighted4");
                    }
                    else if (i == 5)
                    {
                        anim.SetTrigger("Highlighted5");
                    }
                    else if (i == 6)
                    {
                        anim.SetTrigger("Highlighted6");
                    }
                    else if (i == 7)
                    {
                        anim.SetTrigger("Highlighted7");
                    }
                    else if (i == 8)
                    {
                        anim.SetTrigger("Highlighted8");
                    }
                    else if (i == 9)
                    {
                        anim.SetTrigger("Highlighted9");
                    }
                    else if (i == 10)
                    {
                        anim.SetTrigger("Highlighted10");
                    }
                    else if (i == 11)
                    {
                        anim.SetTrigger("Highlighted11");
                    }
                    else if (i == 12)
                    {
                        anim.SetTrigger("Highlighted12");
                    }
                    else if (i == 13)
                    {
                        anim.SetTrigger("Highlighted13");
                    }
                    else if (i == 14)
                    {
                        anim.SetTrigger("Highlighted14");
                    }
                    else if (i == 15)
                    {
                        anim.SetTrigger("Highlighted15");
                    }
                    else if (i == 16)
                    {
                        anim.SetTrigger("Highlighted16");
                    }
                    else if (i == 17)
                    {
                        anim.SetTrigger("Highlighted17");
                    }
                    else if (i == 18)
                    {
                        anim.SetTrigger("Highlighted18");
                    }
                    else if (i == 19)
                    {
                        anim.SetTrigger("Highlighted19");
                    }
                    else if (i == 20)
                    {
                        anim.SetTrigger("Highlighted20");
                    }
                }
            }
        }
    }
    void Start()
    {
        m_YourFirstButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (gameObject.transform.parent.name == "Test_Button")
        {
            anim.SetTrigger("Pressed");
        }

        if (gameObject.transform.parent.name == "Test_Button (1)")
        {
            anim.SetTrigger("Pressed2");
        }
    }

}
