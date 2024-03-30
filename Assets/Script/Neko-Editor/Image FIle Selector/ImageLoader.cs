using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;
using TMPro;

public class ImageLoader : MonoBehaviour
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

    public RawImage backgroundImage;
    public GameObject union;
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
        ofn.filter = "Image Files\0*.jpg;*.jpeg;*.png\0All Files\0*.*\0\0";
        ofn.file = new string(new char[256]);
        ofn.maxFile = ofn.file.Length;
        ofn.fileTitle = new string(new char[64]);
        ofn.maxFileTitle = ofn.fileTitle.Length;
        ofn.initialDir = Application.dataPath;
        ofn.title = "Select Image File         ~ Neko Editor";
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800;

        if (GetOpenFileName(ref ofn))
        {
            string filePath = ofn.file;
            GetComponent<SetBannerImage>().SetImage(filePath, backgroundImage, union);
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
