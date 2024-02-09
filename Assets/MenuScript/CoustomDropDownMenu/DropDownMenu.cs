using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownMenu : MonoBehaviour
{
    public RectTransform rectTransform;
    public void DropMenu()
    {
        rectTransform = GetComponent<RectTransform>();
        Vector2 sizeDelta = rectTransform.sizeDelta;

        sizeDelta.y = 500f;

        rectTransform.sizeDelta = sizeDelta;
    }
}
