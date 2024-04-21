using System;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class GenerateWaveForm : MonoBehaviour
{
    [Header("Audio Clip")]
    private AudioClip audioClip;  // AudioClip to visualize

    [Header("Wave Image")]
    [Tooltip("Image component where the audio waveform will be drawn.")]
    [SerializeField] private Image waveFormImage;

    [Tooltip("Empty texture where the wave will be drawn as pixels.")]
    private Texture2D texture;

    [Header("Color")]
    public Color32 backgroundColor = Color.black; // Background color of the waveform
    public Color32 waveColor = Color.white;       // Color of the waveform itself

    [Header("Wave Values")]
    [Range(10, 16384)]
    public int textureResolution; // Resolution of the texture used for drawing the waveform
    [SerializeField] private int height, width; // Dimensions of the waveform
    [SerializeField] private float scale = 0.5f, waveHeight = 0.5f, waveWidth = 0.5f, waveOffset = 0.5f; // Scaling factors for the waveform

    [Header("Status Changed")]
    public static bool isAudioChanged; // Flag to indicate if the audio has changed

    private void Update()
    {
        if (isAudioChanged)
            InitializeWaveValues();
    }
    private void InitializeWaveValues()
    {
        Color color = waveFormImage.color;
        color.a = 1f;
        waveFormImage.color = color;
        SetGraphicResulution();
        if (NekoMap.audioClip != null)
        {
            audioClip = NekoMap.audioClip;

            DrawWaveForm();
        }

    }


    // Draw the pixal wave art for audio clip
    private void DrawWaveForm()
    {
        int totalSample = audioClip.samples * audioClip.channels;

        float[] samples = new float[totalSample];

        audioClip.GetData(samples, 0);

        int step = Mathf.FloorToInt(samples.Length / (float)width);
        texture.filterMode = FilterMode.Point;

        int midPoint = height / 2;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                texture.SetPixel(x, y, backgroundColor);
            }
        }

        for (int x = 0; x <= width; x++)
        {
            int sampleIndex = x * step;

            if (sampleIndex < samples.Length)
            {
                float sample = samples[sampleIndex];
                int normalizedSample = Mathf.FloorToInt((sample * waveHeight + waveOffset) * height * scale);

                int startY = Mathf.Clamp(midPoint - normalizedSample + midPoint, 0, height);
                int endY = Mathf.Clamp(midPoint + normalizedSample - midPoint, 0, height);

                for (int y = startY; y <= endY; y++)
                {
                    texture.SetPixel(x, y, waveColor);
                }
            }

        }

        texture.Apply();

        waveFormImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);

        isAudioChanged = false;
    }

    // set's the texture width and height.
    private void SetGraphicResulution()
    {
        if (TryGetComponent<RectTransform>(out RectTransform rectTransform))
        {
            width = Mathf.Min(16384, Mathf.FloorToInt(rectTransform.sizeDelta.x));
            height = Mathf.FloorToInt(rectTransform.sizeDelta.y);


            if (texture == null || texture.width != width || texture.height != height)
            {
                texture = new Texture2D(width, height, TextureFormat.RGBA32, false)
                {
                    filterMode = FilterMode.Point
                };
            }
        }
    }
}
