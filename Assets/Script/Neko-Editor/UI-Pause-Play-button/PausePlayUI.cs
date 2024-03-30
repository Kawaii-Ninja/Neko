using UnityEngine;
using UnityEngine.UI;

public class PausePlayUI : MonoBehaviour
{
    [SerializeField] RawImage rawImage;
    [SerializeField] Texture2D play;
    [SerializeField] Texture2D pause;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        rawImage.texture = pause;
    }

    public void ChangeTexture()
    {
        if (rawImage.texture.name == "Play-40-40")
        {
            rawImage.texture = pause;
            audioSource.Play();
        }
        else
        {
            rawImage.texture = play;
            audioSource.Pause();
        }
    }
}
