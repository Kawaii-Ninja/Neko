using UnityEngine;

public static class PlatformCheck
{
    public static int CurrentPlatform()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            return 0;
        }
        else if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer)
        {
            return 1;
        }
        else if (Application.platform == RuntimePlatform.LinuxEditor || Application.platform == RuntimePlatform.LinuxPlayer)
        {
            return 2;
        }
        else
        {
            return 404;
        }
    }
}
