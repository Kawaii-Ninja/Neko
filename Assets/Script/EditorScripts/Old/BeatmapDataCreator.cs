using System.IO;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;

public class BeatmapDataCreator : MonoBehaviour
{
    public TMP_InputField beatmapNameField;
    private string folderPath;
    static public string nekoFilePath;
    string _FileFormat = ".Neko";
    string _FolderName = "NekoBeatMapData";

    private void Awake()
    {
        // Define the path to the folder where you want to save the neko file
        folderPath = Path.Combine(Application.persistentDataPath, _FolderName);

        // Create the folder if it doesn't exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    public void SaveData()
    {
        //store the data to NekoData.
        NekoData userData = new() 
        {
            userName = beatmapNameField.text,
            audioFileName = Path.GetFileName(MusicFileUploader.audioFilePath),
            audioFilePath = MusicFileUploader.audioFilePath
        };

        if (!string.IsNullOrEmpty(userData.audioFileName) && !string.IsNullOrEmpty(userData.userName)) //Check if the input data is empty or null.
        {
            nekoFilePath = Path.Combine(folderPath, userData.userName + _FileFormat);
            // Serialize to binary
            BinaryFormatter binaryFormatter = new();
            using (FileStream fileStream = new(nekoFilePath, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStream, userData);
            }
            Debug.Log($"{userData.userName} Data saved to {nekoFilePath}");
        }
        else
        {
            Debug.LogWarning("Audio file name or user name is null or empty.");
        }
    }
}

[System.Serializable]
public class NekoData
{
    public string userName;
    public string audioFileName;
    public string audioFilePath;
}