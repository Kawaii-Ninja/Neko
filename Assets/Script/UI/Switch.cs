using UnityEngine;
using UnityEngine.EventSystems;

public class Switch : MonoBehaviour, IPointerClickHandler
{
    [Header("Switch Button Object")]
    public GameObject onSwitch;
    public GameObject offSwitch;


    [Header("Switch Status")]
    public bool isOn = true;


    [Header("Switch Audio")]
    public AudioSource audioSource;
    public AudioClip audioOn;
    public AudioClip audioOff;


    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("clickecd:  " + eventData.pointerId);
        if (eventData.pointerId == -1)
        {
            SwitchToggle();
        }
    }

    private void SwitchToggle()
    {
        isOn = !isOn;
        if (isOn)
        {
            Debug.Log(isOn);
            audioSource.clip = audioOn;
            audioSource.Play();
            onSwitch.SetActive(true);
            offSwitch.SetActive(false);
        }
        else
        {
            audioSource.clip = audioOff;
            audioSource.Play();
            onSwitch.SetActive(false);
            offSwitch.SetActive(true);
        }
    }
}
