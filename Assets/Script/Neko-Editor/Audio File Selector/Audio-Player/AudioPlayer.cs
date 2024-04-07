using System.Collections;
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
        PausePlayUI.IsPause = false;
        AudioMetaData metaData = AudioReader.GetMetaData(audioPath);
        NekoMap.audioDuration = AudioReader.GetMetaData(audioPath).durationSeconds;
        audioSource.clip = audioClip;
        progressBar.ProgressData(metaData.durationSeconds, audioSource, !PausePlayUI.IsPause);
        audioTrackInfo.AudioMetaData(audioSource.clip.name, AudioFormatUtility.FormatLength(NekoMap.audioDuration, 1));
        StartCoroutine(LoopAudio());
    }

    IEnumerator LoopAudio()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);

        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            audioSource.time = 0;
            audioSource.Play(0);
            yield return new WaitUntil(() => !audioSource.isPlaying && !PausePlayUI.IsPause);
        }
    }
}
