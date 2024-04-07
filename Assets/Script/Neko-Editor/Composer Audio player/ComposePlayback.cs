using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComposePlayback : MonoBehaviour
{
    public Message message;
    public ComposerProgressbar progressbar;


    public void PlayBack(AudioSource audioSource, Slider slider, TextMeshProUGUI time)
    {
        slider.maxValue = NekoMap.audioDuration == 1 ? 1 : NekoMap.audioDuration;

        if (audioSource.clip != null)
        {
            progressbar.ProgressBar(audioSource, slider, time);
        }
    }


}
