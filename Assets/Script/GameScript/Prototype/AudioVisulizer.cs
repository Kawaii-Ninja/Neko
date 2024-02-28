using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public GameObject visualizerBarPrefab;
    public int numberOfBars = 64;
    GameObject[] bars;
    public AudioSource audioSource;
     public AudioClip audioClip;
     public float radius = 5f;

    void Start()
    {
        bars = new GameObject[numberOfBars];
        audioSource.clip = audioClip; 

        // Calculate the angle increment between bars
        float angleIncrement = 360f / numberOfBars;

        for (int i = 0; i < numberOfBars; i++)
        {
            // Calculate the position of the bar in a circular pattern
            float angleDegrees = i * angleIncrement;
            float angleRadians = angleDegrees * Mathf.Deg2Rad;
            Vector3 barPosition = new Vector3(Mathf.Cos(angleRadians) * radius, Mathf.Sin(angleRadians) * radius, 0);

            // Instantiate the bar at the calculated position
            GameObject bar = Instantiate(visualizerBarPrefab, barPosition, Quaternion.identity, transform);

            // Calculate the rotation angle such that the bar faces outward. We subtract 90 degrees because the bars "up" might be aligned differently.
            float rotationAngle = angleDegrees - 90;
            bar.transform.rotation = Quaternion.Euler(0, 0, rotationAngle);

            bars[i] = bar;
        }
    }

void Update()
{
    float[] spectrum = new float[numberOfBars];
    audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

    for (int i = 0; i < numberOfBars; i++)
    {
        Vector3 scale = bars[i].transform.localScale;
        scale.y = spectrum[i] * 40 + 1; // Adjust Y for vertical bars
        bars[i].transform.localScale = scale;
    }
}
}
