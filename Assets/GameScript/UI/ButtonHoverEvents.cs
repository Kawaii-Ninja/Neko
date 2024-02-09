using System.Collections;
using UnityEngine;

public class ButtonHoverEvents : MonoBehaviour
{
    [SerializeField] AudioSource[] s_MenuButtons;

    public void OnResumButtonPointerEnter()
    {
        s_MenuButtons[0].Play();
    }
    public void OnRestartButtonPointerEnter()
    {
        s_MenuButtons[1].Play();
    }
    public void OnQuitButtonPointerEnter()
    {
        s_MenuButtons[2].Play();
    }


}
