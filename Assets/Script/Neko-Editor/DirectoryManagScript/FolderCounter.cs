using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FolderCounter : MonoBehaviour
{
    static public int CountFolders(string path)
    {
        string[] directories = Directory.GetDirectories(path);
        int folderCount = directories.Length;
        return folderCount;
    }
}
