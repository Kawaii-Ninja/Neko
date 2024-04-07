using UnityEngine;
using System;


public static class Convert24BitByteArray
{
    public static float[] Convert24BitPCMByteArrayToFloatArray(byte[] byteArray)
    {
        try
        {
            int len = byteArray.Length / 3; // Three bytes per sample
            float[] floatArr = new float[len];

            for (int i = 0; i < len; i++)
            {
                int intValue = (byteArray[i * 3 + 2] << 16) | (byteArray[i * 3 + 1] << 8) | byteArray[i * 3];
                if ((intValue & 0x00800000) > 0) intValue |= unchecked((int)0xFF000000);

                floatArr[i] = intValue / 8388608f;
            }

            // Debug.Log($"24-bit integer array converted to float array: length is {floatArr.Length}");

            return floatArr;
        }
        catch (Exception e)
        {
            Debug.LogError($"Error converting audio data: {e.Message}");
            return null;
        }
    }
}