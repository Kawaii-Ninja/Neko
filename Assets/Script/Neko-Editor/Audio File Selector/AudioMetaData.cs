using System;


[Serializable]
public class AudioMetaData
{
    public string title;
    public string artist;
    public string album;
    public int year;
    public int bitrate;
    public int bitDepth;
    public int durationSeconds;
    public int sampleRate;
    public int channels;
    public long fileSizeBytes;
}