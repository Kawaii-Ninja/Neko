using System;
using UnityEngine;

public class WaveForm : MonoBehaviour
{
    public Switch m_Switch;

    public GameObject waveForm;


    private void Update()
    {
        if (m_Switch != null)
        {
            if (m_Switch.isOn)
            {
                ShowWaveForm();
            }
            else
            {
                HideWaveForm();
            }
        }
    }

    private void HideWaveForm()
    {
        waveForm.SetActive(false);
    }

    private void ShowWaveForm()
    {
        waveForm.SetActive(true);
    }
}
