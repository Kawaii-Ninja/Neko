using UnityEngine;

[System.Serializable]
public static class NekoMap
{
    [Header("Beat Map Meta Data")]
    public static string mapName;
    public static string audioName;
    public static string audioPath;
    public static string imagePath;
    public static string authorName;
    public static string creatorName;
    public static string gener;
    public static string source;
    public static string version;
    public static AudioClip audioClip;
    public static float audioDuration;

    [Header("Beat Map Difficulty")]
    public static float level;
    public static float speed;
    public static float duration;
    public static float accuracy;

    [Header("Beat Map Binary Audio and Image")]
    public static byte[] backGroundImage;
    public static byte[] mapAudio;

}