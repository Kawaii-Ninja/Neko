using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InteractivePlaybackController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Playback components")]
    [Tooltip("Components used to change playback position via mouse scrolling")]
    [SerializeField] Slider slider;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] TextMeshProUGUI text;

    [Header("Status")]
    public static bool isHovering;
    public static bool isScrolling;

    [Header("Audio values")]
    float timeChangeAmount;
    float maxTimeScale;
    public float time;

    [Header("Audio Component")]
    [SerializeField] AudioSource audioSource;

    public void InitializeAudioProgressBar(AudioSource audio, TextMeshProUGUI time)
    {
        if (audioSource == null)
        {
            audioSource = audio;
            text = time;
        }

        Debug.Log($"time = {this.time}");
        if (isHovering)
            ChangePlaybackPosistion();

        if (text != null && audioSource != null) UpdateInterActiveUI();
    }


    private void ChangePlaybackPosistion()
    {
        maxTimeScale = audioSource.clip.length;
        timeChangeAmount = maxTimeScale / 10;
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scrollWheelInput) > 0.01f)
        {
            isScrolling = true;

            if (scrollWheelInput > 0)
            {
                Debug.Log("Scrolled Up");
                time += Mathf.Clamp(timeChangeAmount, 0, audioSource.clip.length);
            }
            else
            {
                Debug.Log("Scrolled Down");
                time -= Mathf.Clamp(timeChangeAmount, 0, audioSource.clip.length);
            }


            time = Mathf.Clamp(time, 0, audioSource.clip.length);
            audioSource.time = time;

        }
        else
        {
            isScrolling = false;
        }

    }

    // Update slider and scroll rect
    private void UpdateInterActiveUI()
    {
        if (!ScrollProgressBar.isScrollUpdating && !SliderProgressBar.isSliderUpdating)
        {
            {

                slider.value = Mathf.Lerp(slider.value, Mathf.Clamp(time, 0, audioSource.clip.length), 0.100f);
                float normalizedPosition = slider.value / maxTimeScale;
                scrollRect.horizontalNormalizedPosition = normalizedPosition;
                text.text = AudioFormatUtility.FormatLength(slider.value, 2);
            }
        }
    }


    public float ReverseNormalizerValue(float normalizedValue)
    {
        float orginalValue = -audioSource.clip.length;
        float reversedNormalizedValue = normalizedValue;
        float value = reversedNormalizedValue * orginalValue;
        return value;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
