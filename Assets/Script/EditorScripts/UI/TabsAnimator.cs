using UnityEngine;

public class TabsAnimator : MonoBehaviour
{
    public void AnimationControllerTabOne(Animator animator)
    {
        animator.SetTrigger("Tab1");
    }
    public void AnimationControllerTabTwo(Animator animator)
    {
        animator.SetTrigger("Tab2");
    }
    public void AnimationControllerTabThree(Animator animator)
    {
        animator.SetTrigger("Tab3");
    }
    public void AnimationControllerTabFour(Animator animator)
    {
        animator.SetTrigger("Tab4");
    }
}
