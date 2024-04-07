using UnityEngine;
using System;
using System.IO;

public class AudioHandler : MonoBehaviour
{
    public Message message;
    public AudioLoader audioLoader;
    public AudioPlayer m_AudioPlayer;
    public GameObject audioPlayer;
    string fileName;

    private void Awake()
    {
        // Throw exception if message or AudioLoader is null
        if (message == null)
        {
            throw new System.Exception("Message component is not assigned.");
        }
        if (audioLoader == null)
        {
            throw new System.Exception("Audio Loader component is not assigned.");
        }
        if (m_AudioPlayer == null)
        {
            throw new System.Exception("Audio Player component is not assigned.");
        }
    }

    public void LoadAudio(string audioPath)
    {
        byte[] audioData = LoadAudioData(audioPath);
        audioPlayer.SetActive(false);
        fileName = Path.GetFileNameWithoutExtension(audioPath);
        try
        {
            if (audioData != null)
            {
                NekoMap.mapAudio = audioData;
                AudioClip audioClip = CreateAudioClip(audioData, audioPath);
                NekoMap.audioClip = CreateAudioClip(audioData, audioPath);
                audioPlayer.SetActive(true);
                m_AudioPlayer.Play(audioClip, audioPath);
                audioLoader.feedBackText.text = audioPath.Replace("\\n", "\\N");
                Debug.Log("audio playing");
            }
        }
        catch (Exception e)
        {
            HandleAudioLoadError($"Failed to load Audio from {audioPath}. Error: {e.Message}");
        }
    }


    public byte[] LoadAudioData(string audioPath)
    {
        byte[] audioData = null;
        try
        {
            audioData = File.ReadAllBytes(audioPath);
        }
        catch (Exception e)
        {
            HandleAudioLoadError($"Failed to load Audio from {audioPath}. Error: {e.Message}");
        }
        return audioData;
    }

    private AudioClip CreateAudioClip(byte[] audioData, string audioPath)
    {
        AudioClip audioClip = null;
        try
        {
            audioClip = CheckAudioFormat(audioPath) switch
            {
                "WAVE" => WavUtility.ToAudioClip(audioData, fileName, audioPath),
                "MP3" => MP3Utility.ToAudioClip(MP3Decoder.DecodeMP3(audioPath), fileName, audioPath),
                _ => throw new Exception("Not supported audio format"),
            };
        }
        catch (Exception e)
        {
            HandleAudioLoadError($"Failed to load Error: {e.Message}");
        }
        return audioClip;
    }

    // Handle Audio Load Error message.
    private void HandleAudioLoadError(string errorMessage)
    {
        message.MessageDispatcher("Audio Load Error", errorMessage, "ERROR");
    }
    //set error message and dispatch.
    private void SetErrorMessage(string path, string header, string body)
    {
        audioLoader.feedBackText.text = path + " Error, Audio is not supported.";
        message.MessageDispatcher(header, body, "ERROR");
    }

    private string CheckAudioFormat(string audioPath)
    {

        // Debug.Log(AudioReader.GetMetaData(audioPath).title);
        // Debug.Log(AudioReader.GetMetaData(audioPath).sampleRate);
        // Debug.Log(AudioReader.GetMetaData(audioPath).bitrate);
        // Debug.Log(AudioReader.GetMetaData(audioPath).durationSeconds);

        string extension = Path.GetExtension(audioPath);


        if (extension == ".wav")
        {
            // This is a WAV file
            // Debug.Log("Wave");
            return "WAVE";
        }
        else if (extension == ".mp3")
        {
            // This is an MP3 file
            // Debug.Log("Mp3");
            return "MP3";
        }
        else
        {
            // Unsupported audio format
            return "UNSUPPORTED_AUDIO_FILE_FORMAT";
        }

    }
}


