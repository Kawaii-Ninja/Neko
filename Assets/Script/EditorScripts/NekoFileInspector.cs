using System.IO;
using TMPro;
using UnityEngine;

public class NekoFileInspector : MonoBehaviour
{
    static public int totalFiles;
    [SerializeField] TextMeshProUGUI filesNum;
    private string format = ".neko";
    private string folderName = "NekoBeatMap";
    private string folderPath;

    private void Awake()
    {
        totalFiles = NekoFileCounter();
    }
    public bool CheckPathExist()
    {
        // Define the path to the folder where you want to save the neko file
        folderPath = Path.Combine(Application.persistentDataPath, folderName);

        if (Directory.Exists(folderPath))
            return true;

        return false;


    }
    public int NekoFileCounter()
    {
        if (CheckPathExist())
        {
            string[] nekoFiles = Directory.GetFiles(folderPath, $"*{format}");
            int totalFiles = nekoFiles.Length;
            filesNum.text = totalFiles.ToString();
            return totalFiles;
        }
        return 0;
    }
}
