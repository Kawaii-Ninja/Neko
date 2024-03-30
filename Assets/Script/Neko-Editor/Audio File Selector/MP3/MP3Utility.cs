using UnityEngine;
public static class MP3Utility
{
    public static AudioClip ToAudioClip(byte[] mp3Data, string name, string path)
    {
        AudioClip audioClip = null;
        AudioMetaData reader = AudioReader.GetMetaData(path);

        float[] samples = Convert16BitByteArray.Convert16BitPCMByteArrayToFloatArray(mp3Data);
        audioClip = AudioClip.Create(name, samples.Length, reader.channels, reader.sampleRate, false);
        audioClip.SetData(samples, 0);

        return audioClip;

    }

}
