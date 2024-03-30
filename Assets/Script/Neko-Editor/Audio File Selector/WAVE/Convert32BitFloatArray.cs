using System;
using UnityEngine;

public static class Convert32BitFloatArray
{
    // Method to convert a byte array containing 32-bit float audio data into a float array
    public static float[] Convert32BitFloatArrayToFloatArray(byte[] byteArray)
    {
        try
        {
            int len = byteArray.Length / 4; 
            Debug.Log($"Length of byte array: {byteArray.Length}, Expected length of float array: {len}");

            float[] floatArr = new float[len];
            for (int i = 0; i < len; i++)
            {
                floatArr[i] = BitConverter.ToSingle(byteArray, i * 4);
                Debug.Log($"Converted float at index {i}: {floatArr[i]}");
            }
            Debug.Log($"32-bit float audio converted to float array: length is {floatArr.Length}");
            return floatArr;
        }
        catch (Exception e)
        {
            Debug.LogError($"Error converting audio data: {e.Message}");
            return null;
        }
    }
}
