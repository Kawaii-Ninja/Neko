public static class CheckImageAspectRatio
{
    public static bool CheckRatio(float imageWidth, float imageHeight)
    {
        float desiredAspectRatio = 1f;
        return imageWidth / imageHeight >= desiredAspectRatio;
    }
}
