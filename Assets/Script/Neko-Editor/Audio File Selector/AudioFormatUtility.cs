using UnityEngine;
public static class AudioFormatUtility
{
    public static string FormatLength(float length, int type)
    {
        int minutes = Mathf.FloorToInt(length / 60F);
        int seconds = Mathf.FloorToInt(length % 60F);
        int milliseconds = Mathf.FloorToInt(length * 1000 % 1000);

        if (type == 1)
        {
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (type == 2)
        {
            return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
        else
        {
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
