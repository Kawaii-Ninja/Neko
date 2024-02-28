using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class SaveBeatMap : MonoBehaviour
{
    static NekoData nekoData;

    public string _FolderName = "/Song";
    public string _FileFormat = ".Neko";

    [Header("Beat Map Data")]
    [SerializeField] TMP_InputField _mapName;
    [SerializeField] TMP_InputField _audioName;
    [SerializeField] TMP_InputField _audioPath;
    [SerializeField] TMP_InputField _authorName;
    [SerializeField] TMP_InputField _creatorName;
    [SerializeField] string _bannerImage;
    [SerializeField] string _Image;
    [SerializeField] int _levelType;


    private void Awake() {
        nekoData = new();
    }

    public void SaveMapData()
    {
        FileStream fileStream = File.Open(Application.dataPath + _FolderName + _FileFormat, FileMode.OpenOrCreate);

        BinaryFormatter binaryFormatter = new();

        binaryFormatter.Serialize(fileStream, nekoData);
        fileStream.Close();
    }

    public void AssignMapData()
    {
        
    }
}
