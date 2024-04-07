using TagLib;

public static class AudioReader
{
    public static AudioMetaData GetMetaData(string filePath)
    {
        AudioMetaData audioMetaData = new();
        File file = File.Create(filePath);

        audioMetaData.title = file.Tag.Title;
        audioMetaData.artist = file.Tag.FirstPerformer;
        audioMetaData.album = file.Tag.Album;
        audioMetaData.year = (int)file.Tag.Year;
        audioMetaData.bitrate = file.Properties.AudioBitrate;
        audioMetaData.bitDepth = BitDepth(file);
        audioMetaData.durationSeconds = (int)file.Properties.Duration.TotalSeconds;
        audioMetaData.sampleRate = file.Properties.AudioSampleRate;
        audioMetaData.channels = file.Properties.AudioChannels;
        audioMetaData.fileSizeBytes = new System.IO.FileInfo(filePath).Length;

        return audioMetaData;
    }

    private static int BitDepth(File file)
    {
        if (file.Properties.AudioBitrate == 320000)
        {
            return 24;
        }
        else if (file.Properties.AudioBitrate == 256000)
        {
            return 24;
        }
        else if (file.Properties.AudioBitrate == 256000)
        {
            return 24;
        }
        else
        {
            return 8;
        }
    }
}


