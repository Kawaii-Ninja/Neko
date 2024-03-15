using UnityEngine;
using UnityEngine.EventSystems;

public class SliderHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private AudioSource audioSource;
    private bool isHovering = false;
    private bool isHold = false;
    private bool isAudioPlayed = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHold = false;
    }

    private void Update()
    {
        // Handle hover and click
        if (isHold)
        {
            HandleClickHold();
        }
        else
        {
            HandleHover();
        }
    }

    private void HandleHover()
    {
        if (isHovering)
        {
            if (!isAudioPlayed)
            {
                // Play sound only if AudioSource is available
                if (audioSource != null)
                {
                    audioSource.Play();
                    isAudioPlayed = true;
                }
            }
            // Debug.Log("Hovering");
        }
        else
        {
            isAudioPlayed = false;
            // Debug.Log("Not Hovering");
        }
    }

    private void HandleClickHold()
    {
        isHovering = false;
    }
}
