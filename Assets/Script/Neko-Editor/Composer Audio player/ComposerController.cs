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
        if (!audioSource.isPlaying && !ComposerAudioPlayer.isAudioPause)
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
        audio.Play();
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
        rawImage.texture = play;
        // audio.Stop();
    }
}
