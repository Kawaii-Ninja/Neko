using UnityEngine;
using System;
using TMPro;
public class AudioLoader : MonoBehaviour
{
    public TextMeshProUGUI feedBackText;
    public Message message;
    new AudioHandler audio;

    private string originalDirectory;

    private void Start()
    {
        originalDirectory = Environment.CurrentDirectory;
        audio = GetComponent<AudioHandler>();

    }

    private void OnDestroy()
    {
        Environment.CurrentDirectory = originalDirectory;
    }

    public void OpenFileBrowser()
    {

        if (PlatformCheck.CurrentPlatform() == 0)
        {
            WindowAudioFileBrowser();
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


    private void WindowAudioFileBrowser()
    {
        string path = WindowBrowser.WindowAudioFileBrowser();
        if (path != null)
        {
            audio.LoadAudio(@$"{path}");
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
