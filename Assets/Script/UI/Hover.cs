using System.Collections;
using System.Collections.Generic;
using TagLib.Id3v2;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Hover status")]
    bool isHover;

    [Header("Hover Object")]
    public GameObject highlight;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;
        HoverUpdate();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;
        HoverUpdate();
    }

    private void HoverUpdate()
    {
        highlight.SetActive(isHover);
    }
}
