using System.Collections;
using TMPro;
using UnityEngine;

public class AudioTrackInfoManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI header;

    [SerializeField] TextMeshProUGUI length;

    public void AudioMetaData(string _header, string _length)
    {
        header.text = _header;
        length.text = _length;
    }

}
