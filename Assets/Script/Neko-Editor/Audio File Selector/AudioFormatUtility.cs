using UnityEngine;
public static class AudioFormatUtility
{
    public static string FormatLength(float length)
    {
        int minutes = Mathf.FloorToInt(length / 60F);
        int seconds = Mathf.FloorToInt(length % 60F);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
