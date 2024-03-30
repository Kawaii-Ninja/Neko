using UnityEngine;
using NAudio.Wave;
using System;
using System.IO;
public static class MP3Decoder
{
    public static byte[] DecodeMP3(string mp3Audio)
    {
        if (!File.Exists(mp3Audio))
        {
            Console.WriteLine($"File not found: {mp3Audio}");
            return null;
        }
        Debug.Log("check 1");
        using (Mp3FileReader reader = new Mp3FileReader(mp3Audio))
        {
            Debug.Log("check 2");
            // Convert the audio to 32-bit floating-point PCM
            using (WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(reader))
            {
                Debug.Log("check 3");
                MemoryStream memoryStream = new MemoryStream();
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = pcmStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, bytesRead);
                }
                Debug.Log("check 4");
                Console.WriteLine("MP3 File Converted to 32-bit PCM");
                return memoryStream.ToArray();

            }
        }
    }
}


