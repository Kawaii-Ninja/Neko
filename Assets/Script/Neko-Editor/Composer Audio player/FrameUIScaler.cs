using UnityEngine;

public class FrameUIScaler : MonoBehaviour
{
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        int ms = Mathf.FloorToInt(NekoMap.audioDuration * 1000) + 1629;
        rectTransform.sizeDelta = new Vector2(ms, rectTransform.sizeDelta.y);

    }
}
