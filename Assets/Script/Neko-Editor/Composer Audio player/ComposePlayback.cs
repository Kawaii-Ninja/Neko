using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComposePlayback : MonoBehaviour
{
    public ComposerProgressbar audioProgressbar;
    public ComposerProgressbar scrollProgressbar;

    public void PlayBack(AudioSource audioSource, Slider slider, ScrollRect scrollRect, TextMeshProUGUI time)
    {
        slider.maxValue = NekoMap.audioDuration == 1 ? 1 : NekoMap.audioDuration;

        if (audioSource.clip != null)
        {
            audioProgressbar.InitializeProgressBar(audioSource, time);
            scrollProgressbar.InitializeProgressBar(audioSource, time);
        }
    }


}
