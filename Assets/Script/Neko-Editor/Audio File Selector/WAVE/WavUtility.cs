using UnityEngine;
using System.IO;

public static class WavUtility
{
    public static AudioClip ToAudioClip(byte[] wavData, string name)
    {
        // Read WAV header
        MemoryStream stream = new(wavData);
        BinaryReader reader = new(stream);

        // Check WAV file format
        string riff = new(reader.ReadChars(4));
        int chunkSize = reader.ReadInt32();
        string format = new(reader.ReadChars(4));
        Debug.Log("line 16 " + riff);
        Debug.Log("line 17 " + format);
        // Ensure the file is a WAV file
        if (riff != "RIFF" || format != "WAVE")
        {
            Debug.LogError($"Invalid WAV file format. {format}");
            return null;
        }

        // Read sub-chunk 1 (audio format)
        string subChunk1ID = new(reader.ReadChars(4));
        int subChunk1Size = reader.ReadInt32();
        ushort audioFormat = reader.ReadUInt16();
        ushort numChannels = reader.ReadUInt16();
        int sampleRate = reader.ReadInt32();
        int byteRate = reader.ReadInt32();
        ushort blockAlign = reader.ReadUInt16();
        ushort bitsPerSample = reader.ReadUInt16();


        // Read sub-chunk 2 (audio data)
        string subChunk2ID = new(reader.ReadChars(4));
        int subChunk2Size = reader.ReadInt32();
        byte[] audioData = reader.ReadBytes(subChunk2Size);

        reader.Close();
        stream.Close();

        // Create audio clip
        AudioClip audioClip = null;

        if (bitsPerSample == 16)
        {
            if (audioFormat == 1)
            {
                float[] samples = Convert16BitByteArray.Convert16BitPCMByteArrayToFloatArray(audioData);
                audioClip = AudioClip.Create(name, samples.Length, numChannels, sampleRate, false);
                audioClip.SetData(samples, 0);
            }
            else
            {
                Debug.Log("Error setting data: Unsupported audio format.");
                return null;
            }
        }
        else if (bitsPerSample == 24)
        {
            if (audioFormat == 1)
            {
                Debug.Log($"audioData.Length: {audioData.Length}");
                Debug.Log($"bitsPerSample: {bitsPerSample}");
                Debug.Log($"numChannels: {numChannels}");
                float[] samples = Convert24BitByteArray.Convert24BitPCMByteArrayToFloatArray(audioData);
                audioClip = AudioClip.Create(name, samples.Length, numChannels, sampleRate, false);
                audioClip.SetData(samples, 0);
            }
            else
            {
                Debug.Log("Error setting data: Unsupported audio format.");
                return null;
            }
        }
        else if (bitsPerSample == 32)
        {
            if (audioFormat == 1)
            {
                float[] samples = Convert32BitByteArray.Convert32BitPCMByteArrayToFloatArray(audioData);
                audioClip = AudioClip.Create(name, samples.Length, numChannels, sampleRate, false);
                audioClip.SetData(samples, 0);
            }
            else if (audioFormat == 3)
            {
                float[] samples = Convert32BitFloatArray.Convert32BitFloatArrayToFloatArray(audioData);
                Debug.Log($"audioData.Length: {audioData.Length}");
                Debug.Log($"bitsPerSample: {bitsPerSample}");
                Debug.Log($"numChannels: {numChannels}");

                audioClip = AudioClip.Create(name, samples.Length / (bitsPerSample / 8) / numChannels, numChannels, sampleRate, false);

                audioClip.SetData(samples, 0);
            }
            else
            {
                Debug.Log("Error setting data: Unsupported audio format.");
                return null;
            }
        }
        else
        {
            Debug.Log($"{bitsPerSample} bit is not supported currently.");
        }


        return audioClip;
    }





}
