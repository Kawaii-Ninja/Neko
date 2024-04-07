// using System.IO;
// using UnityEngine;
// using System.Runtime.Serialization.Formatters.Binary;

// public class BinarySerializer : MonoBehaviour
// {
//     public NekoMetaData nekoMetaData;
//     // private NekoMap nekoMap;
//     private string folderPath;
//     private string format = ".neko";
//     private string folderName = "NekoBeatMap";

//     private void Awake()
//     {
//         CreateDirectory();
//     }

//     public void CreateDirectory()
//     {
//         // Define the path to the folder where you want to save the neko file
//         folderPath = Path.Combine(Application.persistentDataPath, folderName);

//         // Create the folder if it doesn't exist
//         if (!Directory.Exists(folderPath))
//         {
//             Directory.CreateDirectory(folderPath);
//         }
//     }

//     public void SerializeData()
//     {
//         nekoMap = nekoMetaData.RetriveData();
//         SaveSerializedData(nekoMap);
//     }

//     public void SaveSerializedData(NekoMap nekoMap)
//     {
//         string filepath = Path.Combine(folderPath, nekoMap.mapName + format);
//         ConvertToBinary(nekoMap, filepath);
//         Debug.Log($"Data saved : {filepath}");
//     }

//     public void ConvertToBinary(NekoMap nekoMap, string filepath)
//     {
//         BinaryFormatter binaryFormatter = new BinaryFormatter();

//         using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
//         {
//             binaryFormatter.Serialize(fileStream, nekoMap);
//         }
//     }
// }
