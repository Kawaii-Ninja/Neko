using System;
using UnityEngine;
using UnityEngine.UI;

public class PausePlayUI : MonoBehaviour
{
    [SerializeField] RawImage rawImage;
    [SerializeField] Texture2D play;
    [SerializeField] Texture2D pause;
    [SerializeField] AudioSource audioSource;
    public static bool IsPause = false;

    private void Start()
    {
        rawImage.texture = pause;
    }

    private void Update()
    {
        if (IsPause)
        {
            rawImage.texture = play;
        }
        else
        {
            rawImage.texture = pause;
        }
    }

    public void ChangeTexture()
    {
        if (audioSource.isPlaying)
        {
            Pause();
        }
        else
        {
            Play();
        }
    }

    private void Pause()
    {
        rawImage.texture = play;
        audioSource.Pause();
        IsPause = true;
    }

    private void Play()
    {
        rawImage.texture = pause;
        audioSource.Play();
        IsPause = false;
    }
}
