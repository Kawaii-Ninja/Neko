using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ScrollProgressBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler, IBeginDragHandler
{
    [Header("Status")]
    [Tooltip("To check current status.")]
    bool isDragging;
    public static bool isHovering;
    bool isHolding;

    public static bool isScrollUpdating;

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

    public bool OnScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void UpdateScrollStatus()
    {
        if (isDragging && isHolding || OnScroll())
        {
            isScrollUpdating = true;
        }
        else
        {
            isScrollUpdating = false;
        }
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


    // Check if the audio is playing and update the UI for the timeline progress bar.
    private void UpdateProgressBarUI()
    {
        UpdateScrollStatus();
        try
        {
            if (_audio.clip != null)
            {
                if (IsAudioPlayingWithinBounds() && !InteractivePlaybackController.isScrolling && !OnScroll() && !isDragging && !isHolding && !SliderProgressBar.isSliderUpdating)
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


    // Change the value on scroll and update the UI;
    public void UpdatePlaybackPosition()
    {
        if (isDragging && isHolding)
        {
            float value = Mathf.Abs(ReverseNormalizerValue(scrollRect.horizontalNormalizedPosition));
            float time = Mathf.Clamp(value, 0, _audio.clip.length);
            _slider.value = time;
            _audio.time = time;
            _text.text = AudioFormatUtility.FormatLength(_slider.value, 2);
            interactivePlaybackController.time = _slider.value;
        }
        else if (OnScroll())
        {
            float value = Mathf.Abs(ReverseNormalizerValue(scrollRect.horizontalNormalizedPosition));
            float time = Mathf.Clamp(value, 0, _audio.clip.length);
            _slider.value = time;
            _audio.time = time;
            _text.text = AudioFormatUtility.FormatLength(_slider.value, 2);
            interactivePlaybackController.time = _slider.value;
        }
    }


    // Reverse the normalized value (0 : 1)
    public float ReverseNormalizerValue(float normalizedValue)
    {
        float orginalValue = -_audio.clip.length;
        float reversedNormalizedValue = normalizedValue;
        float value = reversedNormalizedValue * orginalValue;
        return value;
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
