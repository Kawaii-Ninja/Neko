using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderSoundEffect : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] Slider slider;
    [SerializeField] float playDelayed = 0.05f;
    private float lastSliderValue;

    void Start()
    {
        slider.value = 0;
        slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(slider.value); });
    }

    private void OnSliderValueChanged(float value)
    {
        float roundedValue = Mathf.Round(value * 10f) / 10f;

        if (lastSliderValue != roundedValue)
        {
            PlayAudio(audioClip);
            slider.value = roundedValue;
            lastSliderValue = roundedValue;
        }
        else
        {
            slider.value = lastSliderValue;
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = audioClip;
            // audioSource.Play();
            audioSource.PlayDelayed(playDelayed);
        }
    }


}
