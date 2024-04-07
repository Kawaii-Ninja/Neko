using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator animator;
    bool isHolding;
    // private void Update()
    // {
    //     Debug.Log(isHolding);

    // }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHolding) 
        {
            animator.SetBool("Hovering", true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isHolding) 
        {
            animator.SetBool("Hovering", false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true; 
        // animator.SetBool("Hovering", false);
        animator.SetBool("Holding", true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        // animator.SetBool("Hovering", false);
        animator.SetBool("Holding", false);
    }


}
