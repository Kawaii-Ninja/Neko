using UnityEngine;
using UnityEngine.UI;

public static class ChangeImageAspectRatio
{
    public static void ChangeImageRatio(Texture2D imageTexture, RawImage rawImage)
    {
        float imageAspectRatio = (float)imageTexture.width / imageTexture.height;
        float rawImageWidth = rawImage.rectTransform.rect.width; 
        rawImage.rectTransform.sizeDelta = new Vector2(rawImageWidth, rawImageWidth / imageAspectRatio);
    }

}
