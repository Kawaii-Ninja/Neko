using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;
using TMPro;
public class AudioLoader : MonoBehaviour
{
    [DllImport("comdlg32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool GetOpenFileName(ref OpenFileName ofn);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct OpenFileName
    {
        public int structSize;
        public IntPtr hwndOwner;
        public IntPtr hInstance;
        public string filter;
        public string customFilter;
        public int maxCustFilter;
        public int filterIndex;
        public string file;
        public int maxFile;
        public string fileTitle;
        public int maxFileTitle;
        public string initialDir;
        public string title;
        public int flags;
        public short fileOffset;
        public short fileExtension;
        public string defExt;
        public IntPtr custData;
        public IntPtr hook;
        public string templateName;
        public IntPtr reservedPtr;
        public int reservedInt;
        public int flagsEx;
    }

    public TextMeshProUGUI feedBackText;
    public Message message;

    private string originalDirectory;

    private void Start()
    {
        originalDirectory = Environment.CurrentDirectory;
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
        OpenFileName ofn = new();
        ofn.structSize = Marshal.SizeOf(ofn);
        ofn.filter = "Audio Files\0*.wav;*.mp3;\0All Files\0*.*\0\0";
        ofn.file = new string(new char[256]);
        ofn.maxFile = ofn.file.Length;
        ofn.fileTitle = new string(new char[64]);
        ofn.maxFileTitle = ofn.fileTitle.Length;
        ofn.initialDir = Application.dataPath;
        ofn.title = "Select Audio File         ~ Neko Editor";
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800;

        if (GetOpenFileName(ref ofn))
        {
            string filePath = ofn.file;

            GetComponent<AudioHandler>().LoadAudio(filePath);
        }
        else
        {
            Debug.Log("File selection cancelled or encountered an error.");
        }

        Environment.CurrentDirectory = originalDirectory;
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
