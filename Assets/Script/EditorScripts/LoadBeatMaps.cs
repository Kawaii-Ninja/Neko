using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadBeatMaps : MonoBehaviour
{
    string foldePath;
    public string fileName;
    public void FindFile() 
    {
        foldePath = Path.Combine(Application.persistentDataPath, "NekoBeatMapData");

        string filePath = Path.Combine(foldePath, fileName);
        LoadData(filePath);
    }

private void LoadData(string filePath)
{
    if (File.Exists(filePath))
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            // Debugging: Print the type of the object being deserialized
            Debug.Log("Deserializing object of type: " + fileStream.GetType().Name);

            // Deserialize the data from the file
            object deserializedObject = binaryFormatter.Deserialize(fileStream);

            // Debugging: Print the type of the deserialized object
            Debug.Log("Deserialized object of type: " + deserializedObject.GetType().Name);

            // Cast the deserialized object to NekoFileData
            NekoFileData nekoFileData = (NekoFileData)deserializedObject;

            Debug.Log("Loaded user name: " + nekoFileData.userName);
            Debug.Log("Loaded file name: " + nekoFileData.audioFileName);
            Debug.Log("Loaded file path: " + nekoFileData.audioFilePath);
        }
    }
    else
    {
        Debug.LogWarning("File not found: " + filePath);
    }
}

}


[Serializable]
public class NekoFileData
{
    public string userName;
    public string audioFileName;
    public string audioFilePath;
}