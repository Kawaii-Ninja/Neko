using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Analytics;

public class ComposerProgressbar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [Header("Status")]
    [Tooltip("To cheack current status")]
    bool isDragging;


    [Header("Components")]
    AudioSource _audio;
    TextMeshProUGUI _text;
    [SerializeField] Slider _slider;
    [SerializeField] ScrollRect scrollRect;


    public void InitializeProgressBar(AudioSource audio, TextMeshProUGUI time)
    {
        if (_audio == null)
        {
            _audio = audio;
            _text = time;
        }
        UpdateUI();

    }


    // check the audio is playing & Update the UI for time line progress bar; 
    private void UpdateUI()
    {
        try
        {
            if (_audio.clip != null)
            {
                if (IsAudioPlayingOrEnded() && !isDragging)
                {
                    {
                        // Update UI while audio is playing
                        float normalizedPosition = Mathf.InverseLerp(0, _audio.clip.length, _audio.time);
                        scrollRect.horizontalNormalizedPosition = normalizedPosition;
                        _slider.value = Mathf.Clamp(_audio.time, 0, _audio.clip.length);
                        _text.text = AudioFormatUtility.FormatLength(_audio.time, 2);
                    }
                }
                else if (Mathf.Clamp(_audio.time, 0, _audio.clip.length) >= _audio.clip.length)
                {
                    _audio.Pause();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e.ToString());
        }

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {

        isDragging = false;
    }


    // Change the slider value and update the UI;
    public void OnSliderPlayBackValueChange()
    {
        if (_audio != null && _slider != null && isDragging)
        {
            _audio.time = _slider.value;
            float normalizedPosition = _slider.value / _audio.clip.length;
            scrollRect.horizontalNormalizedPosition = Mathf.Clamp(normalizedPosition, 0, _audio.clip.length);
            _text.text = AudioFormatUtility.FormatLength(_slider.value, 2);
        }
        UpdateUI();
    }


    // Change the value on scroll and update the UI;
    public void OnScrollPlayBackValueChange()
    {
        if (_audio != null && scrollRect != null)
        {
            float value = Mathf.Abs(ReverseNormalizerValue(scrollRect.horizontalNormalizedPosition));
            float time = Mathf.Clamp(value, 0, _audio.clip.length);
            _audio.time = time;
            _slider.value = time;
            _text.text = AudioFormatUtility.FormatLength(_slider.value, 2);
        }
        UpdateUI();
    }


    // Reverse the normalized value (0 : 1)
    public float ReverseNormalizerValue(float normalizedValue)
    {
        float orginalValue = -_audio.clip.length;
        float reversedNormalizedValue = normalizedValue;
        float value = reversedNormalizedValue * orginalValue;
        return value;
    }


    // Check's if the audio is ended or playing;
    public bool IsAudioPlayingOrEnded()
    {
        float currentTime = Mathf.Clamp(_audio.time, 0, _audio.clip.length);
        if (currentTime != 0)
        {
            {

                return true;

            }
        }
        return false;
    }

}
