using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ImageLoader : MonoBehaviour
{
    public RawImage backgroundImage;
    public GameObject union;
    public TextMeshProUGUI feedBackText;
    public Message message;
    SetBannerImage image;


    private string originalDirectory;

    private void Start()
    {
        originalDirectory = Environment.CurrentDirectory;
        image = GetComponent<SetBannerImage>();
    }

    private void OnDestroy()
    {
        Environment.CurrentDirectory = originalDirectory;
    }

    public void OpenFileBrowser()
    {

        if (PlatformCheck.CurrentPlatform() == 0)
        {
            WindowFileBrowser();
        }
        else if (PlatformCheck.CurrentPlatform() == 1)
        {
            OSXFileBrowser();
        }
        else if (PlatformCheck.CurrentPlatform() == 2)
        {
            LinuxFileBrowser();
        }
        else if (PlatformCheck.CurrentPlatform() == 404)
        {
            message.MessageDispatcher("404 ERROR: Platform not supported", $"Your current platform is {Application.platform} ", "ERROR");
        }

    }


    private void WindowFileBrowser()
    {
        string path = WindowBrowser.WindowImageFileBrowser();
        if (path != null)
        {
            image.SetImage(path, backgroundImage, union);
        }
    }

    private void LinuxFileBrowser()
    {
        message.MessageDispatcher("404 ERROR: Platform not supported", $"Your current platform ({Application.platform}) is not supported during development.", "ERROR");
    }

    private void OSXFileBrowser()
    {
        message.MessageDispatcher("404 ERROR: Platform not supported", $"Your current platform ({Application.platform}) is not supported during development.", "ERROR");
    }
}
