using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NekoMetaData : MonoBehaviour
{
    // NekoMap _nekoData;

    [Header("Beat Map Data")]
    [SerializeField] TMP_InputField _mapName;
    [SerializeField] TMP_InputField _audioName;
    [SerializeField] TextMeshProUGUI _audioPath;
    [SerializeField] TMP_InputField _authorName;
    [SerializeField] TMP_InputField _creatorName;

    [SerializeField] Slider _level;
    [SerializeField] Slider _speed;
    [SerializeField] Slider _duration;
    [SerializeField] Slider _accuracy;

    // private void Awake()
    // {
    //     _nekoData = new();
    // }

    public string RetriveData()
    {

        // _nekoData.mapName = _mapName.text;
        // _nekoData.audioName = _audioName.text;
        // _nekoData.authorName = _authorName.text;
        // _nekoData.creatorName = _creatorName.text;
        // _nekoData.audioPath = _audioPath.text;
        // _nekoData.level = (int)_level.value;
        // _nekoData.speed = (int)_speed.value;
        // _nekoData.duration = (int)_duration.value;
        // _nekoData.accuracy = (int)_accuracy.value;

        return "a";
    }

    // public void ShowData()
    // {
    //     RetriveData();
    //     Debug.Log("Neko map Data : " + _nekoData.mapName);
    //     Debug.Log("Neko map Data : " + _nekoData.audioName);
    //     Debug.Log("Neko map Data : " + _nekoData.authorName);
    //     Debug.Log("Neko map Data : " + _nekoData.creatorName);
    //     Debug.Log("Neko map Data : " + _nekoData.audioPath);
    //     Debug.Log("Neko map Data : " + _nekoData.level);
    //     Debug.Log("Neko map Data : " + _nekoData.speed);
    //     Debug.Log("Neko map Data : " + _nekoData.duration);
    //     Debug.Log("Neko map Data : " + _nekoData.accuracy);
    // }

}
