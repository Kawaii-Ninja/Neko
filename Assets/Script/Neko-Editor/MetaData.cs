using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MetaData : MonoBehaviour
{
    [Header("Beat Map Data")]
    [SerializeField] TMP_InputField m_MapName;
    [SerializeField] TMP_InputField m_AudioName;
    [SerializeField] TextMeshProUGUI m_AudioPath;
    [SerializeField] TMP_InputField m_AuthorName;
    [SerializeField] TMP_InputField m_CreatorName;
    [SerializeField] TMP_InputField m_Gener;
    [SerializeField] TMP_InputField m_Source;
    [SerializeField] TMP_InputField m_Version;

    [SerializeField] Slider _level;
    [SerializeField] Slider _speed;
    [SerializeField] Slider _duration;
    [SerializeField] Slider _accuracy;

    private void Update()
    {
        NekoMap.mapName = m_MapName.text;
        NekoMap.audioName = m_AudioName.text;
        NekoMap.authorName = m_AuthorName.text;
        NekoMap.creatorName = m_CreatorName.text;
        NekoMap.gener = m_Gener.text;
        NekoMap.source = m_Source.text;
        NekoMap.version = m_Version.text;
        NekoMap.audioPath = m_AudioPath.text;
        NekoMap.level = _level.value;
        NekoMap.speed = _speed.value;
        NekoMap.duration = _duration.value;
        NekoMap.accuracy = _accuracy.value;

    }

    // private void FixedUpdate()
    // {
    //     Debug.Log(NekoMap.mapName);
    //     Debug.Log(NekoMap.audioName);
    //     Debug.Log(NekoMap.audioPath);
    //     Debug.Log(NekoMap.accuracy);
    // }
}
