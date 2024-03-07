using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] AudioSource audioSource;
    float previousValue = 1f;

    private void Start()
    {
        slider.value = 1; //default value.
        slider.onValueChanged.AddListener(delegate { AdjustSliderValue(); }); //check if the value changed.
    }

    // Audio Play Logic.
    private void AdjustSliderValue()
    {
        //check if the Slider value is smaller then 0.5
        if (slider.value < 1.5f)
        {
            slider.value = 1;
            if (slider.value == 1f && previousValue != 1f) //check if the previous value is not the same as current value
            {
                previousValue = 1;
                audioSource.Play();
            }
        }
        //check if the Slider value is smaller then 1.5 and Greater then 0.5
        else if (slider.value >= 1.5f && slider.value < 2.5f)
        {
            slider.value = 2;
            if (slider.value == 2f && previousValue != 2f) //check if the previous value is not the same as current value
            {
                previousValue = 2f;
                audioSource.Play();
            }
        }
        //check if the Slider value is Greater then 1.5 
        else if (slider.value >= 2.5f)
        {
            slider.value = 3;
            if (slider.value == 3f && previousValue != 3f) //check if the previous value is not the same as current value
            {
                previousValue = 3f;
                audioSource.Play();
            }
        }
    }
}
