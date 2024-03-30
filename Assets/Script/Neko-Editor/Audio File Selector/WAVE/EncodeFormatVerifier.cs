using UnityEngine;

public static class EncodeFormatVerifier
{
    public static bool IsPCMInt32BitFormat(float[] dataArray)
    {
        foreach (float sample in dataArray)
        {
            if (sample < -2147483648f || sample > 2147483647f)
                return false;
        }
        return true;
    }
}
