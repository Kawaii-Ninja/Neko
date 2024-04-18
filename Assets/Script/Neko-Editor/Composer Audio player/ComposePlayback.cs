using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComposePlayback : MonoBehaviour
{
    public SliderProgressBar audioProgressbar;
    public ScrollProgressBar scrollProgressbar;
    public InteractivePlaybackController interactivePlaybackController;

    public void PlayBack(AudioSource audioSource, Slider slider, ScrollRect scrollRect, TextMeshProUGUI time)
    {
        slider.maxValue = NekoMap.audioDuration == 1 ? 1 : NekoMap.audioDuration;

        if (audioSource.clip != null)
        {
            if (SliderProgressBar.isHovering)
            {
                audioProgressbar.InitializeAudioProgressBar(audioSource, time);
            }
            else if (ScrollProgressBar.isHovering)
            {
                scrollProgressbar.InitializeAudioProgressBar(audioSource, time);
            }
            else
            {
                audioProgressbar.InitializeAudioProgressBar(audioSource, time);
                interactivePlaybackController.InitializeAudioProgressBar(audioSource, time);
            }
        }
    }


}
