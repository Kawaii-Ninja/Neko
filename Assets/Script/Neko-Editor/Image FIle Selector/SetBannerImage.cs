using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetBannerImage : MonoBehaviour
{
    public Message message;
    public ImageLoader imageLoader;
    public RawImage backgroundImage;

    private void Awake()
    {
        // Throw exception if message or imageLoader is null
        if (message == null)
        {
            throw new System.Exception("Message component is not assigned.");
        }
        if (imageLoader == null)
        {
            throw new System.Exception("ImageLoader component is not assigned.");
        }
    }

    public void SetImage(string filePath, RawImage image, GameObject u)
    {
        // Set background Image to banner.
        try
        {
            byte[] imageData = File.ReadAllBytes(filePath);
            LoadImageIntoBanner(imageData, image, u, filePath);
        }
        catch (IOException e)
        {
            HandleImageLoadError($"Failed to load image from {filePath}. Error: {e.Message}");
        }

    }

    private void LoadImageIntoBanner(byte[] imageData, RawImage image, GameObject u, string path)
    {
        Texture2D dataTexture = new(2, 2);
        try
        {
            if (dataTexture.LoadImage(imageData))
            {
                if (CheckImageAspectRatio.CheckRatio(dataTexture.width, dataTexture.height))
                {

                    NekoMap.backGroundImage = imageData;
                    NekoMap.imagePath = path;
                    ChangeImageAspectRatio.ChangeImageRatio(dataTexture, image);
                    ChangeImageAspectRatio.ChangeImageRatio(dataTexture, backgroundImage);
                    image.texture = dataTexture;
                    backgroundImage.texture = dataTexture;
                    u.SetActive(false);
                    imageLoader.feedBackText.text = path;
                }
                else
                {
                    // u.SetActive(true);
                    // set error message.
                    SetErrorMessage(path, "Image Aspect Ratio Error", $"The selected image's aspect ratio ({dataTexture.width} x {dataTexture.height}) is not supported. Currently, only images with an aspect ratio greater than 1 are supported and best fit for the game.");
                    SetErrorMessage(path, "Unknown ", $"{Application.persistentDataPath}");
                }
            }
            else
            {
                // set error message.
                SetErrorMessage(path, "Image Format Error", "The selected image format is not supported. Please choose a different image.");
            }
        }
        catch (IOException e)
        {
            // Set Image Load Error.
            HandleImageLoadError($"Failed to load image from {path}. Error: {e.Message}");
        }

    }

    // private void ChangeImageAspectRatio(Texture2D dataTexture, RawImage image)
    // {
    //     float imageAspectRatio = (float)dataTexture.width / dataTexture.height;

    //     image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.width / imageAspectRatio);

    // }


    // Handle image Load Error message.
    private void HandleImageLoadError(string errorMessage)
    {
        message.MessageDispatcher("Image Load Error", errorMessage, "ERROR");
    }

    //set error message and dispatch.
    private void SetErrorMessage(string path, string header, string body)
    {
        imageLoader.feedBackText.text = path + " Error, Image is not supported.";
        message.MessageDispatcher(header, body, "ERROR");
    }
}
