using System;
using UnityEngine;

public static class Convert32BitByteArray
{
    // Method to convert a byte array containing 32-bit PCM audio data into a float array

    public static float[] Convert32BitPCMByteArrayToFloatArray(byte[] byteArray)
    {
        try
        {
            int len = byteArray.Length / 4;
            float[] floatArr = new float[len];

            for (int i = 0; i < len; i++)
            {
                int intValue = BitConverter.ToInt32(byteArray, i * 4);
                floatArr[i] = intValue / (int.MaxValue + 1.0f);
            }

            // Debug.Log($"32-bit integer array converted to float array : length is {floatArr.Length}");

            return floatArr;
        }
        catch (Exception e)
        {
            Debug.LogError($"Error converting audio data: {e.Message}");
            return null;
        }
    }
}
