using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetBannerImage : MonoBehaviour
{
    public Error error;
    public void SetImage(string filePath, RawImage image, GameObject u)
    {
        try
        {

            byte[] imageData = File.ReadAllBytes(filePath);
            LoadImageIntoBanner(imageData, image, u);

        }
        catch (IOException e)
        {
            Debug.LogError($"Failed to load image from {filePath}. Error: {e.Message}");
            error.NotificationError("Image Load Error", "We're sorry, we couldn't load your image. Please try again.");
        }

    }

    private void LoadImageIntoBanner(byte[] imageData, RawImage image, GameObject u)
    {
        u.SetActive(false);
        Texture2D dataTexture = new(2, 2);
        if (dataTexture.LoadImage(imageData))
        {

            if (ChackImageAspectRatio(dataTexture.width, dataTexture.height))
            {
                image.texture = dataTexture;
                image.SetNativeSize();
            }
            else
            {
                error.NotificationError("Image Aspect Ratio Error", "The selected image's aspect ratio is not supported. Please choose an image with an aspect ratio greater than 1.");
            }
        }
        else
        {
            error.NotificationError("Image Format Error", "Tthe Selected image format is not supported. Please choose a different image.");
        }

    }

    private bool ChackImageAspectRatio(float imageWidth, float imageHeight)
    {
        float desiredAspectRatio = 1f;

        if (imageWidth / imageHeight >= desiredAspectRatio)
        {
            return true;
        }
        else
        {
            string header = "Image Aspect Ratio Error";
            string body = $"The selected image's aspect ratio ({imageWidth} x {imageHeight}) is not supported. Currently, only images with an aspect ratio greater than 1 are supported and best fit for the game.";
            error.NotificationError(header, body);
            return false;
        }
    }
}
