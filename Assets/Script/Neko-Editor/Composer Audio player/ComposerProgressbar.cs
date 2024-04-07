using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ComposerProgressbar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isDragging;
    AudioSource _audio;
    Slider _slider;
    TextMeshProUGUI _text;
    public void ProgressBar(AudioSource audio, Slider slider, TextMeshProUGUI time)
    {
        if (_audio == null && _slider == null)
        {
            // Debug.Log("Check 3");
            _audio = audio;
            _slider = slider;
            _text = time;
        }

    }
    private void Update()
    {
        // Debug.Log("Check 4");
        if (_audio.isPlaying)
        {
            _slider.value = _audio.time;
            _text.text = AudioFormatUtility.FormatLength(_slider.value, 2);
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

    public void OnPlayBackValue()
    {

        if (_audio != null && _slider != null && isDragging)
        {
            _audio.time = _slider.value;
            _text.text = AudioFormatUtility.FormatLength(_slider.value, 2);
        }
    }
}
