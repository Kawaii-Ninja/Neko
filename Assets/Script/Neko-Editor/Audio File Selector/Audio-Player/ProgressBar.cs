using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ProgressBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Slider progressBar;
    [SerializeField] TextMeshProUGUI timer;
    bool isSeeking = false;
    float m_Second;
    bool isAudioPlaying;
    bool isDragging;
    public AudioSource m_Asource;
    void Update()
    {
        if (!isDragging && m_Asource != null && progressBar != null && isAudioPlaying)
        {
            Debug.Log("1");
            progressBar.value = m_Asource.time / m_Second;
            timer.text = AudioFormatUtility.FormatLength(m_Asource.time);
        }

        if (m_Asource.time == m_Second)
        {
            m_Asource.Stop();
            Debug.Log("777");
            // StartCoroutine(RestartAusio());
        }
    }

    public void ProgressData(float s, AudioSource source, bool _isPlaying)
    {
        m_Second = s;
        m_Asource = source;
        isAudioPlaying = _isPlaying;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (m_Asource != null && progressBar != null)
        {
            m_Asource.time = progressBar.value * m_Second;
        }
        isDragging = false;
    }

    IEnumerator RestartAusio()
    {
        yield return new WaitForSeconds(2f);
        progressBar.value = 0;
    }
}
