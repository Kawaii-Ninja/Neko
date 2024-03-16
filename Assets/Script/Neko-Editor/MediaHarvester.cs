using UnityEngine;

public class MediaHarvester : MonoBehaviour
{
    static public byte[] m_backgroundImage;

    public void ShowDataImfo()
    {
        Debug.Log(m_backgroundImage.Length);
    }
}
