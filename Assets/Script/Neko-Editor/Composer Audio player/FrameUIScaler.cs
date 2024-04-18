using UnityEngine;

public class FrameUIScaler : MonoBehaviour
{
    public RectTransform mapRectTransform;
    public RectTransform waveFormRectTransform;
    public RectTransform framRectTransform;

    private void Update()
    {
        int ms = Mathf.FloorToInt(NekoMap.audioDuration * 1000);
        mapRectTransform.sizeDelta = new Vector2(ms, mapRectTransform.sizeDelta.y);
        waveFormRectTransform.sizeDelta = new Vector2(ms, waveFormRectTransform.sizeDelta.y);
        framRectTransform.sizeDelta = new Vector2(ms, framRectTransform.sizeDelta.y);

    }
}
