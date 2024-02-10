using System.IO;
using UnityEngine;
using TMPro;

public class BeatmapDataCreator : MonoBehaviour
{
    public TMP_InputField beatmapNameField;
    private string folderPath;
    private string jsonFilePath;

    private void Awake()
    {
        // Define the path to the folder where you want to save the JSON file
        folderPath = Path.Combine(Application.persistentDataPath, "UserBeatMapEditorData");

        // Create the folder if it doesn't exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }
    public void SaveData()
    {
        UserData userData = new()
        {
            userName = beatmapNameField.text,
            audioFileName = Path.GetFileName(MusicFileUploader.audioFilePath),
            audioFilePath = MusicFileUploader.audioFilePath
        };

        if(userData.audioFileName != null && userData.userName != null)
        {
        jsonFilePath = Path.Combine(folderPath, $"{userData.userName}.json");
         string jsonData = JsonUtility.ToJson(userData);
         File.WriteAllText(jsonFilePath, jsonData);
         Debug.Log($"{userData.userName} Data saved to {jsonFilePath}");
        }
    }


}

[System.Serializable]
public class UserData
{
    public string userName;
    public string audioFileName;
    public string audioFilePath;
}

