using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
public class SliderProgressBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler, IBeginDragHandler
{
    [Header("Status")]
    [Tooltip("To check current status.")]
    bool isDragging;
    public static bool isHovering;
    bool isHolding;
    public static bool isSliderUpdating;

    [Header("Components")]
    AudioSource _audio;
    TextMeshProUGUI _text;
    [SerializeField] Slider _slider;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] InteractivePlaybackController interactivePlaybackController;


    // To check current status.
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        isHolding = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }



    public void InitializeAudioProgressBar(AudioSource audio, TextMeshProUGUI time)
    {
        if (_audio == null)
        {
            _audio = audio;
            _text = time;
        }
        UpdateProgressBarUI();
    }


    public void UpdateSliderStatus()
    {
        if (isDragging && isHolding)
        {
            isSliderUpdating = true;
        }
        else
        {
            isSliderUpdating = false;
        }
    }


    // Check if the audio is playing and update the UI for the timeline progress bar.
    private void UpdateProgressBarUI()
    {
        UpdateSliderStatus();
        try
        {
            if (_audio.clip != null)
            {
                if (IsAudioPlayingWithinBounds() && !InteractivePlaybackController.isScrolling && !isDragging && !isHolding && !ScrollProgressBar.isScrollUpdating)
                {
                    {
                        // Update UI while audio is playing
                        float normalizedPosition = Mathf.InverseLerp(0, _audio.clip.length, _audio.time);
                        scrollRect.horizontalNormalizedPosition = normalizedPosition;
                        _slider.value = Mathf.Clamp(_audio.time, 0, _audio.clip.length);
                        _text.text = AudioFormatUtility.FormatLength(_audio.time, 2);
                        interactivePlaybackController.time = _slider.value;

                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e.ToString());
        }

    }


    // Change the slider value and update the UI;
    public void UpdatePlaybackPosition()
    {
        if (_audio != null && _slider != null && isDragging && isHolding)
        {

            float normalizedPosition = _slider.value / _audio.clip.length;
            scrollRect.horizontalNormalizedPosition = Mathf.Clamp(normalizedPosition, 0, _audio.clip.length);
            float time = Mathf.Clamp(_slider.value, 0, _audio.clip.length);
            _audio.time = time;
            _text.text = AudioFormatUtility.FormatLength(_slider.value, 2);
            interactivePlaybackController.time = _slider.value;
        }
    }


    private bool IsAudioPlayingWithinBounds()
    {
        if (_audio.time > 0)
        {
            if (_audio.time <= _audio.clip.length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}
