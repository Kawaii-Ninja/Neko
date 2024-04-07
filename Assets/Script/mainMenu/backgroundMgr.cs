using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class backgroundMgr : MonoBehaviour
{
    [SerializeField]
    private Image imageComponent;
    [SerializeField]
    private Sprite[] images;
    // Start is called before the first frame update
    void Start()
    {
        imageComponent=GetComponent<Image>();
        imageComponent.sprite  = images[UnityEngine.Random.Range(0, images.Length)];
    }
}