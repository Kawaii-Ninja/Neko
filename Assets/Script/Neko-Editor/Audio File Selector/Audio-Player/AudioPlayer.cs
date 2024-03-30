using System.IO;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioTrackInfoManager audioTrackInfo;
    public ProgressBar progressBar;
    public AudioSource audioSource;
    private void Awake()
    {
        // progressBar = GetComponent<ProgressBar>();
        audioTrackInfo = GetComponent<AudioTrackInfoManager>();
    }

    public void Play(AudioClip audioClip, string audioPath)
    {
        AudioMetaData metaData = AudioReader.GetMetaData(audioPath);
        audioSource.clip = audioClip;
        progressBar.ProgressData(metaData.durationSeconds, audioSource, true);
        audioTrackInfo.AudioMetaData(audioSource.clip.name, AudioFormatUtility.FormatLength(AudioReader.GetMetaData(audioPath).durationSeconds));
        audioSource.Play();
    }
}
