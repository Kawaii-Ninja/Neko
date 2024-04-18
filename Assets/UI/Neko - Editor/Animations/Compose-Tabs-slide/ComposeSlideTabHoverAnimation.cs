using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class ComposeSlideTabHoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator animator;
    bool isHovering = false;
    Coroutine smoothTransCoroutine;



    // private void Update()
    // {
    //     Debug.Log(isHovering);
    // }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        // if (smoothTransCoroutine != null)
        // {
        //     StopCoroutine(smoothTransCoroutine);
        // }
        smoothTransCoroutine = StartCoroutine(SmoothTrans());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        if (smoothTransCoroutine != null)
        {
            smoothTransCoroutine = null;
        }
    }
    IEnumerator SmoothTrans()
    {
        yield return new WaitForSeconds(.5f);
        while (isHovering)
        {
            animator.SetBool("Hovering", true);
            yield return null;
        }
        // yield return new WaitForSeconds(1f);
        // if (isHovering)
        // {
        //     smoothTransCoroutine = StartCoroutine(SmoothTrans());
        // }
        // else
        {
            animator.SetBool("Hovering", false);
            StopCoroutine(SmoothTrans());
        }
    }

}
