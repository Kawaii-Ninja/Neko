using System;
using UnityEngine;

public static class Convert16BitByteArray
{
    // Method to convert a byte array containing 16-bit PCM audio data into a float array
    public static float[] Convert16BitPCMByteArrayToFloatArray(byte[] byteArray)
    {
        try
        {
            int len = byteArray.Length / 2;
            float[] floatArr = new float[len];

            for (int i = 0; i < len; i++)
            {
                floatArr[i] = BitConverter.ToInt16(byteArray, i * 2) / 32768.0f;
            }

            // Debug.Log($"16-bit PCM audio converted to float array{floatArr.Length}");
            return floatArr;
        }
        catch (Exception e)
        {
            Debug.LogError($"Error converting audio data: {e.Message}");
            return null;
        }
    }
}
