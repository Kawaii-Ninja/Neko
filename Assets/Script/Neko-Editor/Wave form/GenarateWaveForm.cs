using System;
using UnityEngine;

public class GenarateWaveForm : MonoBehaviour
{
    [Range(0, 1000)]
    public int waveResolution;

    [Range(0, 100)]
    public int scale;

    public AudioSource audioSource;
    float[] audioData;


    private void Update()
    {
        audioData = new float[waveResolution];
        audioSource.GetSpectrumData(audioData, 0, FFTWindow.Blackman);
        DrawWaveform();
    }

    void DrawWaveform()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = waveResolution;

        for (int i = 0; i < waveResolution; i++)
        {
            float x = (float)i / waveResolution * scale;
            float y = audioData[i] * scale;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
