using System;
using System.Collections;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{
    // [SerializeField] Animator animator;
    [Header("Audio player")]
    [SerializeField] AudioSource audioSource;

    [Header("Game")]
    public GameObject m_EditorScreen;

    [Header("Navigation tabs")]
    public GameObject m_Setup;
    public GameObject m_Compose;
    public GameObject m_Timming;
    public GameObject m_Publish;

    [Header("Navegation tabs transform")]
    Transform m_SetupTransform;
    Transform m_TimmingTransform;
    Transform m_PublishTransform;
    Transform m_ComposeTransform;

    [Header("Error")]
    [SerializeField] Message message;


    private void Start()
    {
        try
        {
            if (m_Setup != null)
            {
                m_SetupTransform = m_Setup.GetComponent<Transform>();
            }
            if (m_Compose != null)
            {
                m_ComposeTransform = m_Compose.GetComponent<Transform>();
            }
            if (m_Timming != null)
            {
                m_TimmingTransform = m_Timming.GetComponent<Transform>();
            }
            if (m_Publish != null)
            {
                m_PublishTransform = m_Publish.GetComponent<Transform>();
            }
        }
        catch (Exception e)
        {
            message.MessageDispatcher("Tab component error", $"Somthing went worng{e.Message}", "ERROR");
        }
    }

    // public void SetupAnimation()
    // {
    //     animator.SetBool("Setup", true);
    //     animator.SetBool("Composer", false);
    //     animator.SetBool("Publish", false);
    //     PausePlayUI.IsPause = true;
    // }

    // public void ComposerAnimation()
    // {
    //     animator.SetBool("Composer", true);
    //     animator.SetBool("Setup", false);
    //     animator.SetBool("Publish", false);
    //     PausePlayUI.IsPause = true;
    //     audioSource.Pause();
    // }
    // public void PublishAnimation()
    // {
    //     animator.SetBool("Publish", true);
    //     animator.SetBool("Composer", false);
    //     animator.SetBool("Setup", false);
    //     PausePlayUI.IsPause = true;
    //     audioSource.Pause();
    // }

    public void Setup()
    {
        m_SetupTransform.SetAsLastSibling();
    }

    public void Compose()
    {
        m_ComposeTransform.SetAsLastSibling();
    }

    public void Timming()
    {
        m_TimmingTransform.SetAsLastSibling();
    }

    public void Publish()
    {
        m_PublishTransform.SetAsLastSibling();
    }

}
