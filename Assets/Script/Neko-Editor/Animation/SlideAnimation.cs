using System.Collections;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;

    public void SetupAnimation()
    {
        animator.SetBool("Setup", true);
        animator.SetBool("Composer", false);
        animator.SetBool("Publish", false);
        PausePlayUI.IsPause = true;
    }

    public void ComposerAnimation()
    {
        animator.SetBool("Composer", true);
        animator.SetBool("Setup", false);
        animator.SetBool("Publish", false);
        PausePlayUI.IsPause = true;
        audioSource.Pause();
    }
    public void PublishAnimation()
    {
        animator.SetBool("Publish", true);
        animator.SetBool("Composer", false);
        animator.SetBool("Setup", false);
        PausePlayUI.IsPause = true;
        audioSource.Pause();
    }


}
