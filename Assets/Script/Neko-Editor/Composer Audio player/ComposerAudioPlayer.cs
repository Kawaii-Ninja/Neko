using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComposerAudioPlayer : MonoBehaviour
{
    [Header("Audio Player Status")]
    public static bool isAudioPlaying = false;
    public static bool isAudioPause = true;

    [Header("Audio Player Components")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] Slider progressBar;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] TextMeshProUGUI timeLineText;
    [SerializeField] ComposePlayback composePlayback;

    [Header("Audio Player Error Handels")]
    [SerializeField] Message message;

    private void Start()
    {
        if (audioSource == null)
        {
            throw new System.Exception("Audio Scource is Null");
        }
        if (progressBar == null)
        {
            throw new System.Exception("Progress bar is Null");
        }
        if (timeLineText == null)
        {
            throw new System.Exception("Time Line Text is Null");
        }
        if (NekoMap.audioClip == null)
        {
            audioClip = AudioClip.Create("EmptyClip", 44100, 1, 44100, false);
            NekoMap.audioDuration = audioClip.length;
            audioSource.clip = audioClip;
            composePlayback.PlayBack(audioSource, progressBar, scrollRect, timeLineText);
        }
    }

    private void Update()
    {
        if (CheckExternalAudio())
        {
            audioSource.clip = NekoMap.audioClip;
        }
        composePlayback.PlayBack(audioSource, progressBar, scrollRect, timeLineText);
    }

    private bool CheckExternalAudio()
    {
        if (NekoMap.audioClip == null)
            return false;
        else
            return true;
    }
}
