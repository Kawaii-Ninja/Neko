using UnityEngine;
using UnityEngine.UI;

public class ComposerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] RawImage rawImage;
    [SerializeField] AudioSource audioSource;
    [Header("Image Textures")]
    [SerializeField] Texture2D play;
    [SerializeField] Texture2D pause;

    private void Update()
    {
        if (!AudioStatus())
        {
            Stop(audioSource);
        }
    }
    public void PlayController()
    {
        if (audioSource.isPlaying)
        {
            Pause(audioSource);
        }
        else if (!audioSource.isPlaying)
        {
            Play(audioSource);
        }
    }
    public void Play(AudioSource audio)
    {
        ComposerAudioPlayer.isAudioPause = false;
        rawImage.texture = pause;
        {
            if (audio.time == audio.clip.length)
            {
                audio.time = 0;
            }
            audio.Play();
        }
    }
    public void Pause(AudioSource audio)
    {
        ComposerAudioPlayer.isAudioPause = true;
        rawImage.texture = play;
        audio.Pause();
    }

    public void Stop(AudioSource audio)
    {
        ComposerAudioPlayer.isAudioPause = true;
        if (!audioSource.isPlaying)
        {
            rawImage.texture = play;
        }
    }

    private bool AudioStatus()
    {
        if (audioSource.time > 0)
        {
            if (audioSource.time <= audioSource.clip.length)
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
