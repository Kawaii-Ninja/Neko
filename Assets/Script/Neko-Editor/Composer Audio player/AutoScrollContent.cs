using UnityEngine;
using UnityEngine.UI;

public class AutoScrollContent : MonoBehaviour
{
    public ScrollRect scrollRect;
    public AudioSource audioSource;
    public float scrollSpeed = 1f;

    private void Update()
    {
        if (audioSource.isPlaying)
        {
            float normalizedPosition = Mathf.InverseLerp(0, audioSource.clip.length, audioSource.time);

            scrollRect.horizontalNormalizedPosition = normalizedPosition;

            // // Adjust the speed of scrolling
            // float scrollStep = scrollSpeed * Time.deltaTime;
            // scrollRect.horizontalNormalizedPosition += scrollStep;
        }
    }
}
