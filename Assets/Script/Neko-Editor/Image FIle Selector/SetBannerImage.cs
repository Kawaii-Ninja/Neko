using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetBannerImage : MonoBehaviour
{
    public void SetImage(string filePath, RawImage image, GameObject u)
    {
        try
        {
            
            byte[] imageData = File.ReadAllBytes(filePath);
            LoadImageIntoBanner(imageData, image, u);

        }
        catch (IOException e)
        {
            Debug.LogError(e.Message + " Image Not Loaded Something went worng");
        }

    }

    private void LoadImageIntoBanner(byte[] imageData, RawImage image, GameObject u)
    {
        u.SetActive(false);
        Texture2D dataTexture = new(1920, 1080);
        dataTexture.LoadImage(imageData);

        image.texture = dataTexture;
        image.SetNativeSize();
    }
}
