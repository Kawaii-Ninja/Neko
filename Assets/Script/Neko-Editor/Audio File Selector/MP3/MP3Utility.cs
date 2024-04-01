using UnityEngine;
public static class MP3Utility
{
    public static AudioClip ToAudioClip(byte[] mp3Data, string name, string audioPath)
    {
        AudioMetaData reader = AudioReader.GetMetaData(audioPath);

        float durationInSeconds = reader.durationSeconds;
        float[] samples = Convert16BitByteArray.Convert16BitPCMByteArrayToFloatArray(mp3Data);
        int lengthSamples = Mathf.CeilToInt(durationInSeconds * reader.sampleRate);
        // Debug.Log(reader.sampleRate);
        // Debug.Log(reader.durationSeconds);
        // Debug.Log(reader.channels);
        // Debug.Log(reader.bitrate);
        AudioClip audioClip = AudioClip.Create(name, lengthSamples, reader.channels, reader.sampleRate, false);
        audioClip.SetData(samples, 0);

        return audioClip;

    }

}
